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
        private readonly List<EventAttendee> _eventAttendees = new List<EventAttendee>();

        public IReadOnlyCollection<EventAttendee> EventAttendees => _eventAttendees.AsReadOnly();

        protected Attendee() { }

        protected Attendee(string name, PaymentMethod paymentMethod, string additionalInfo, string participantRequests)
        {
            AttendeeId = Guid.NewGuid();
            Name = name;
            PaymentMethod = paymentMethod;
            AdditionalInfo = additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds max length");
            ParticipantRequests = participantRequests.Length <= 5000 ? participantRequests : throw new ArgumentException("Participant requests exceed max length");
        }
    }

    public class NaturalPersonAttendee : Attendee
    {
        public string PersonalIdCode { get; private set; }

        public NaturalPersonAttendee() { }

        public NaturalPersonAttendee(string name, string personalIdCode, PaymentMethod paymentMethod,
                                     string additionalInfo, string participantRequests)
            : base(name, paymentMethod, additionalInfo, participantRequests)
        {
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendee : Attendee
    {
        public string CompanyName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public int AttendeeCount { get; private set; }

        public LegalEntityAttendee() { }

        public LegalEntityAttendee(string companyName, string registrationCode, int attendeeCount,
                                   PaymentMethod paymentMethod, string additionalInfo, string participantRequests)
            : base(companyName, paymentMethod, additionalInfo, participantRequests)
        {
            CompanyName = companyName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
        }
    }
}
