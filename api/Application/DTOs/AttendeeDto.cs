using api.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Application.DTOs
{
    public class AttendeeDto
    {
        public Guid? Id { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? PersonalIdCode { get; set; }
        public virtual string? LegalName { get; set; }
        public virtual string? CompanyRegistrationCode { get; set; }
        public virtual int? AttendeeCount { get; set; }
        public virtual string? ParticipantRequests { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string? AdditionalInfo { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public virtual AttendeeType Type { get; set; }

        public virtual PaymentMethodDto? PaymentMethod { get; set; }
        public virtual EventDto? Event { get; set; }
        public Guid EventId { get; set; }
        }
    
}
