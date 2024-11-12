using api.Domain.Models;

namespace api.Infrastructure.Entities
{
    public class AttendeeEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Guid EventId { get; protected set; }
        public Event? Event { get; protected set; }
        public string AdditionalInfo { get; protected set; }
        public Guid PaymentMethodId { get; protected set; }

        public PaymentMethodEntity PaymentMethod { get; protected set; }

        public AttendeeEntity() { }

         public AttendeeEntity(Guid eventId, string name, Guid paymentMethodId, string additionalInfo)
        {
            EventId = eventId;
            Id = Guid.NewGuid();
            Name = name;
            PaymentMethodId = paymentMethodId;
            AdditionalInfo = additionalInfo;
        }
    }

    public class NaturalPersonAttendeeEntity : AttendeeEntity
    {
        public NaturalPersonAttendeeEntity() { }
        public string PersonalIdCode { get; private set; }

        public NaturalPersonAttendeeEntity(Guid eventId, string name, string personalIdCode, Guid paymentMethodId, string additionalInfo)
            : base(eventId, name, paymentMethodId,
                   additionalInfo.Length <= 1500 ? additionalInfo : throw new ArgumentException("Additional info exceeds 1500 characters for a natural person"))
        {
            PersonalIdCode = personalIdCode;
        }
    }

    public class LegalEntityAttendeeEntity : AttendeeEntity
    {
        public LegalEntityAttendeeEntity() { }
        public string CompanyName { get; private set; }
        public string CompanyRegistrationCode { get; private set; }
        public int AttendeeCount { get; private set; }
        public string ParticipantRequests { get; private set; } = string.Empty;


        public LegalEntityAttendeeEntity(Guid eventId, string companyName, string registrationCode, int attendeeCount,
                                   Guid paymentMethodId, string additionalInfo, string participantRequests)
            : base(eventId, companyName, paymentMethodId,
                   additionalInfo.Length <= 5000 ? additionalInfo : throw new ArgumentException("Additional info exceeds 5000 characters for a legal entity"))
        {
            CompanyName = companyName;
            CompanyRegistrationCode = registrationCode;
            AttendeeCount = attendeeCount;
            ParticipantRequests = participantRequests;
        }
    }
}