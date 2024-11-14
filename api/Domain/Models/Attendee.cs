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
    }

    public class NaturalPersonAttendee : Attendee
    {
        public NaturalPersonAttendee() { }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PersonalIdCode { get; private set; }

        public NaturalPersonAttendee(Guid eventId, string firstName, string lastName, string personalIdCode, Guid paymentMethodId, string additionalInfo, Guid? id, Event @event, PaymentMethod paymentMethod)
            : base(eventId, paymentMethodId,
                   additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds 1500 characters for a natural person"), id, @event, paymentMethod)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendee : Attendee
    {
        public LegalEntityAttendee() { }
        public string LegalName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public int AttendeeCount { get; private set; }
        public string ParticipantRequests { get; private set; } = string.Empty;


        public LegalEntityAttendee(Guid eventId, string legalName, string registrationCode, int attendeeCount,
                                   Guid paymentMethodId, string additionalInfo, string participantRequests, Guid? id, Event @event, PaymentMethod paymentMethod)
            : base(eventId, paymentMethodId,
                   additionalInfo.Length <= 5000 ? additionalInfo : throw new ArgumentException("Additional info exceeds 5000 characters for a legal entity"), id, @event, paymentMethod)
        {
            LegalName = legalName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
            ParticipantRequests = participantRequests;
        }
    }
}
