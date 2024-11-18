using api.Domain.Enums;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class UpdateAttendeeDto : AttendeeDto
    {
        public new Guid? Id { get => null; set { } }
        public new Guid? EventId { get => null; set { } }
        public new string? FirstName { get; set; }
        public new string? LastName { get; set; }
        public new string? LegalName { get; set; }
        [EstonianIdCode]
        public new string? PersonalIdCode { get; set; }
        public new string? CompanyRegistrationCode { get; set; }
        public new int? AttendeeCount { get; set; }
        public new string? ParticipantRequests { get; set; }
        public new Guid? PaymentMethodId { get; set; }
        public new string? AdditionalInfo { get; set; }
    }
}