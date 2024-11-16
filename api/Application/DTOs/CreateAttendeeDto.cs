using api.Domain.Enums;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class CreateAttendeeDto : AttendeeDto
    {
        [RequiredIfType(AttendeeType.NaturalPerson)]
        public override string? FirstName { get; set; } = string.Empty;

        [RequiredIfType(AttendeeType.NaturalPerson)]
        public override string? LastName { get; set; } = string.Empty;

        [RequiredIfType(AttendeeType.NaturalPerson)]
        public override string? PersonalIdCode { get; set; } = string.Empty;

        [RequiredIfType(AttendeeType.LegalEntity)]
        public override string? LegalName { get; set; } = string.Empty;

        [RequiredIfType(AttendeeType.LegalEntity)]
        public override string? CompanyRegistrationCode { get; set; } = string.Empty;

        [RequiredIfType(AttendeeType.LegalEntity)]
        public override int? AttendeeCount { get; set; } = null;

        [RequiredIfType(AttendeeType.LegalEntity)]
        public override string? ParticipantRequests { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public override AttendeeType Type { get; set; }
    }
}
