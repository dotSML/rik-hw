namespace api.Domain.Models
{
    public class Attendee
    {
        public Guid? AttendeeId { get; protected set; }
        public string Name { get; protected set; }

        public Guid EventId { get; protected set; }
        public Event Event { get; protected set; }
        public string AdditionalInfo { get; protected set; }
        public Guid PaymentMethodId { get; protected set; }

        public PaymentMethod PaymentMethod { get; protected set; }

        protected Attendee() { }

        protected Attendee(Guid eventId, string name, Guid paymentMethodId, string additionalInfo, Guid? id)
        {
            EventId = eventId;
            AttendeeId = id ?? Guid.NewGuid();
            Name = name;
            PaymentMethodId = paymentMethodId;
            AdditionalInfo = additionalInfo;
        }
    }

    public class NaturalPersonAttendee : Attendee
    {
        public NaturalPersonAttendee() { }
        public string PersonalIdCode { get; private set; }

        public NaturalPersonAttendee(Guid eventId, string name, string personalIdCode, Guid paymentMethodId, string additionalInfo, Guid? id)
            : base(eventId, name, paymentMethodId,
                   additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds 1500 characters for a natural person"), id)
        {
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendee : Attendee
    {
        public LegalEntityAttendee() { }
        public string CompanyName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public int AttendeeCount { get; private set; }
        public string ParticipantRequests { get; private set; } = string.Empty;
        public Event Event { get; set; }


        public LegalEntityAttendee(Guid eventId, string companyName, string registrationCode, int attendeeCount,
                                   Guid paymentMethodId, string additionalInfo, string participantRequests, Guid? id)
            : base(eventId, companyName, paymentMethodId,
                   additionalInfo.Length <= 5000 ? additionalInfo : throw new ArgumentException("Additional info exceeds 5000 characters for a legal entity"), id)
        {
            CompanyName = companyName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
            ParticipantRequests = participantRequests;
        }
    }
}
