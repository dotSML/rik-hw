using api.Domain.Enums;
using api.Domain.Models;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class AttendeeDto
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? ParticipantRequests { get; set; }
        public string? PersonalIdCode { get; set; }
        public string? LegalName { get; set; }
        public string? CompanyRegistrationCode { get; set; }
        public int? AttendeeCount { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttendeeType Type { get; set; }
        public EventDto @Event { get; set; }

        public AttendeeDto()
        {

        }

        public AttendeeDto(Attendee attendee)
        {
            Id = attendee.AttendeeId;
            PaymentMethod = attendee.PaymentMethod;
            AdditionalInfo = attendee.AdditionalInfo;
            Type = attendee switch
            {
                NaturalPersonAttendee => AttendeeType.NaturalPerson,
                LegalEntityAttendee => AttendeeType.LegalEntity,
                _ => throw new ArgumentException("Invalid attendee type")
            };

            if (attendee is NaturalPersonAttendee naturalPerson)
            {
                FirstName = naturalPerson.FirstName;
                LastName = naturalPerson.LastName;
                PersonalIdCode = naturalPerson.PersonalIdCode;
            }
            else if (attendee is LegalEntityAttendee legalEntity)
            {
                LegalName = legalEntity.LegalName;
                CompanyRegistrationCode = legalEntity.CompanyRegistrationCode;
                AttendeeCount = legalEntity.AttendeeCount;
                ParticipantRequests = legalEntity.ParticipantRequests;
            }
        }
    }
}
