using api.Domain.Enums;

namespace api.Domain.DTOs
{
    public interface IAttendeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? ParticipantRequests { get; set; }
        public string? PersonalIdCode { get; set; }
        public string? LegalName { get; set; }
        public string? CompanyRegistrationCode { get; set; }
        public int? AttendeeCount { get; set; }
        public AttendeeType Type { get; set; }
    }
}