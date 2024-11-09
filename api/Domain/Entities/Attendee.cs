using System;
using System.Security.Cryptography.X509Certificates;
using api.Domain.Enums;
using api.Domain.ValueObjects;

namespace api.Domain.Entities
{
    public abstract class Attendee
    {
        public Guid AttendeeId { get; protected set; }
        public string Name { get; protected set; }
        public PaymentMethod PaymentMethod { get; protected set; }
        public string AdditionalInfo { get; protected set; } // Up to 1500 characters
        public string ParticipantRequests { get; protected set; } // Up to 5000 characters
        public List<Event> Events { get; private set; } = new List<Event>();

        protected Attendee() { } 

        protected Attendee(string name, PaymentMethod paymentMethod, string additionalInfo, string participantRequests)
        {
            AttendeeId = Guid.NewGuid();
            Name = name;
            PaymentMethod = paymentMethod;
            AdditionalInfo = additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds max length");
            ParticipantRequests = participantRequests.Length <= 5000 ? participantRequests : throw new ArgumentException("Participant requests exceed max length");
        }

        public abstract AttendeeType Type { get; }
    }

    public class NaturalPersonAttendee : Attendee
    {
        public NaturalPersonAttendee() { }
        public string PersonalIdCode { get; private set; }

        public NaturalPersonAttendee(string name, string personalIdCode, PaymentMethod paymentMethod,
                                     string additionalInfo, string participantRequests)
            : base(name, paymentMethod, additionalInfo, participantRequests)
        {
            PersonalIdCode = personalIdCode;
        }

        public override AttendeeType Type => AttendeeType.NaturalPerson;
    }

    public class LegalEntityAttendee : Attendee
    {
        public LegalEntityAttendee() { }

        public string CompanyName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public int AttendeeCount { get; private set; }

        public LegalEntityAttendee(string companyName, string registrationCode, int attendeeCount,
                                   PaymentMethod paymentMethod, string additionalInfo, string participantRequests)
            : base(companyName, paymentMethod, additionalInfo, participantRequests)
        {

            CompanyName = companyName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
        }

        public override AttendeeType Type => AttendeeType.LegalEntity;
    }
}
