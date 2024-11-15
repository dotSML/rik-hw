
namespace api.Infrastructure.Entities
{
    public class AttendeeEntity
    {
        public Guid? Id { get; protected set; }
        
        public Guid EventId { get; protected set; }
        public EventEntity Event { get; protected set; }
        public string? AdditionalInfo { get; protected set; }
        public Guid PaymentMethodId { get; protected set; }

        public PaymentMethodEntity PaymentMethod { get; protected set; }

        public AttendeeEntity() { }

         public AttendeeEntity(Guid? id, Guid eventId, Guid paymentMethodId, string additionalInfo, EventEntity eventEntity, PaymentMethodEntity paymentMethodEntity)
        {
            Event = eventEntity;
            PaymentMethod = paymentMethodEntity;
            EventId = eventId;
            Id = id;
            PaymentMethodId = paymentMethodId;
            AdditionalInfo = additionalInfo;
        }
    }

    public class NaturalPersonAttendeeEntity : AttendeeEntity
    {
        public NaturalPersonAttendeeEntity() { }

        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string PersonalIdCode { get; set; }

        public NaturalPersonAttendeeEntity(Guid eventId, string firstName, string lastName, string personalIdCode, Guid paymentMethodId, string additionalInfo, Guid? id, EventEntity eventEntity, PaymentMethodEntity paymentMethodEntity)
            : base(id, eventId, paymentMethodId,
                   additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds 1500 characters for a natural person"), eventEntity, paymentMethodEntity)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendeeEntity : AttendeeEntity
    {
        public LegalEntityAttendeeEntity() { }
        public string LegalName { get; set; }
        public string CompanyRegistrationCode { get; set; }
        public int AttendeeCount { get; set; }
        public string ParticipantRequests { get; set; } = string.Empty;


        public LegalEntityAttendeeEntity(Guid eventId, string legalName, string registrationCode, int attendeeCount,
                                   Guid paymentMethodId, string additionalInfo, string participantRequests, Guid? id, EventEntity eventEntity, PaymentMethodEntity paymentMethodEntity)
            : base(id, eventId, paymentMethodId,
                   additionalInfo.Length <= 5000 ? additionalInfo : throw new ArgumentException("Additional info exceeds 5000 characters for a legal entity"), eventEntity, paymentMethodEntity)
        {
            LegalName = legalName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
            ParticipantRequests = participantRequests;
        }
    }
}