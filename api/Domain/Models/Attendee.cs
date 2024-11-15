using api.Domain.Enums;

namespace api.Domain.Models
{
    public class Attendee
    {
        public Guid? AttendeeId { get; protected set; }
        public Guid? Id { get; protected set; }
        public Guid EventId { get; protected set; }
        public Event? Event { get; protected set; }
        public string? AdditionalInfo { get; protected set; }
        public Guid PaymentMethodId { get; protected set; }

        public PaymentMethod? PaymentMethod { get; protected set; }

       

        protected Attendee() { }

        protected Attendee(Guid eventId, Guid paymentMethodId, string additionalInfo, Guid? id, Event @event, PaymentMethod paymentMethod)
        {
            Id = id;
            EventId = eventId;
            AttendeeId = id;
            PaymentMethodId = paymentMethodId;
            AdditionalInfo = additionalInfo;
            Event = @event;
            PaymentMethod = paymentMethod;
        }

        public void UpdateAdditionalInfo(string additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }

        public void UpdatePaymentMethodId(Guid paymentMethodId)
        {
            PaymentMethodId = paymentMethodId;
        }
    }

    public class NaturalPersonAttendee : Attendee
    {
        public NaturalPersonAttendee() { }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PersonalIdCode { get; protected set; }

        public NaturalPersonAttendee(Guid eventId, string firstName, string lastName, string personalIdCode, Guid paymentMethodId, string additionalInfo, Guid? id, Event? @event, PaymentMethod? paymentMethod)
            : base(eventId, paymentMethodId,
                   additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds 1500 characters for a natural person"), id, @event, paymentMethod)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalIdCode = personalIdCode;
        }

        public void UpdateFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }

        public void UpdatePersonalIdCode(string personalIdCode)
        {
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendee : Attendee
    {
        public LegalEntityAttendee() { }
        public string LegalName { get; protected set; }
        public string CompanyRegistrationCode { get; protected set; }
        public int AttendeeCount { get; protected set; }
        public string ParticipantRequests { get; protected set; } = string.Empty;


        public LegalEntityAttendee(Guid eventId, string legalName, string registrationCode, int attendeeCount,
                                   Guid paymentMethodId, string additionalInfo, string participantRequests, Guid? id, Event? @event, PaymentMethod? paymentMethod)
            : base(eventId, paymentMethodId,
                   additionalInfo.Length <= 5000 ? additionalInfo : throw new ArgumentException("Additional info exceeds 5000 characters for a legal entity"), id, @event, paymentMethod)
        {
            LegalName = legalName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
            ParticipantRequests = participantRequests;
        }

        public void UpdateLegalName(string legalName)
        {
            LegalName = legalName;
        }

        public void UpdateAttendeeCount(int attendeeCount)
        {
            AttendeeCount = attendeeCount;
        }

        public void UpdateCompanyRegistrationCode(string companyRegistrationCode)
        {
            CompanyRegistrationCode = companyRegistrationCode;
        }

        public void UpdateParticipantRequests(string participantRequests)
        {
            ParticipantRequests = participantRequests;
        }
    }
}
