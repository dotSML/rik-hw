using api.Domain.Enums;
using api.Domain.Models;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class CreateAttendeeDto
    {
        public string Name { get; set; } = string.Empty;

        public Guid EventId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string AdditionalInfo { get; set; } = string.Empty;
        public string ParticipantRequests { get; set; } = string.Empty;
        public string PersonalIdCode { get; set; } = string.Empty;
        public string LegalName { get; set; } = string.Empty;
        public string CompanyRegistrationCode { get; set; } = string.Empty;
        public int AttendeeCount { get; set; }
        public AttendeeType Type { get; set; }
    }
}
