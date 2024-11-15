using api.Domain.DTOs;
using api.Domain.Enums;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class CreateAttendeeDto : AttendeeDto
    {
        [RequiredIfType(AttendeeType.NaturalPerson)]
        public string? FirstName { get; set; } = string.Empty;
        [RequiredIfType(AttendeeType.NaturalPerson)]
        public string? LastName { get; set; } = string.Empty;
        public Guid EventId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string? AdditionalInfo { get; set; } = string.Empty;
        [RequiredIfType(AttendeeType.LegalEntity)]
        public string? ParticipantRequests { get; set; } = string.Empty;
        [RequiredIfType(AttendeeType.NaturalPerson)]
        public string? PersonalIdCode { get; set; } = string.Empty;
        [RequiredIfType(AttendeeType.LegalEntity)]
        public string? LegalName { get; set; } = string.Empty;
        [RequiredIfType(AttendeeType.LegalEntity)]
        public string? CompanyRegistrationCode { get; set; } = string.Empty;
        public int? AttendeeCount { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttendeeType Type { get; set; }
    }
}
