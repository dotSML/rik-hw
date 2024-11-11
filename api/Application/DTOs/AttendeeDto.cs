using api.Domain.Entities;
using api.Domain.Enums;
using api.Domain.ValueObjects;

namespace api.Application.DTOs
{
    public class AttendeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string AdditionalInfo { get; set; }
        public string ParticipantRequests { get; set; }
        public string PersonalIdCode { get; set; }
        public string LegalName { get; set; }
        public string CompanyRegistrationCode { get; set; }
        public int AttendeeCount { get; set; }
        public AttendeeType Type { get; set; }
        public List<EventDto> Events { get; set; } = new List<EventDto>();

        public AttendeeDto()
        {

        }

        public AttendeeDto(Attendee attendee)
        {
            Id = attendee.AttendeeId;
            Name = attendee.Name;
            PaymentMethod = attendee.PaymentMethod;
            AdditionalInfo = attendee.AdditionalInfo;
            ParticipantRequests = attendee.ParticipantRequests;
            Type = attendee switch
            {
                NaturalPersonAttendee => AttendeeType.NaturalPerson,
                LegalEntityAttendee => AttendeeType.LegalEntity,
                _ => throw new ArgumentException("Invalid attendee type")
            };

            if (attendee is NaturalPersonAttendee naturalPerson)
            {
                PersonalIdCode = naturalPerson.PersonalIdCode;
            }
            else if (attendee is LegalEntityAttendee legalEntity)
            {
                LegalName = legalEntity.CompanyName;
                CompanyRegistrationCode = legalEntity.CompanyRegistrationCode;
                AttendeeCount = legalEntity.AttendeeCount;
            }

            Events = attendee.EventAttendees
                        .Select(ea => new EventDto(ea.Event))
                        .ToList();
        }
    }
}
