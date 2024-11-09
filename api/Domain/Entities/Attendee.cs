using api.Domain.Enums;
using api.Domain.ValueObjects;

namespace api.Domain.Entities
{
    public class Attendee
    {
        public Guid AttendeeId { get; private set; }
        public string Name { get; private set; }
        public string IdentificationNumber { get; private set; } 
        public PaymentMethod PaymentMethod { get; private set; }
        public AttendeeType Type { get; private set; }
        public string AdditionalInfo { get; private set; }

        public List<Event> Events { get; private set; }

        public Attendee(string name, string identificationNumber, PaymentMethod paymentMethod, AttendeeType type, string additionalInfo)
        {
            AttendeeId = Guid.NewGuid();
            Name = name;
            IdentificationNumber = identificationNumber;
            PaymentMethod = paymentMethod;
            Type = type;
            AdditionalInfo = additionalInfo;
        }

        public Attendee() { }

        public void UpdateAttendee(string name, string identificationNumber, PaymentMethod paymentMethod, string additionalInfo)
        {
            Name = name;
            IdentificationNumber = identificationNumber;
            PaymentMethod = paymentMethod;
            AdditionalInfo = additionalInfo;
        }
    }

  
}