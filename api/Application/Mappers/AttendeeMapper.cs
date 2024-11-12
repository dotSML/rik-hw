using api.Application.DTOs;
using api.Domain.Enums;
using api.Domain.Models;

public static class AttendeeMapper
{
    public static Attendee ToAttendeeFromCreate(this CreateAttendeeDto dto)
    {
        return dto.Type switch
        {
            AttendeeType.NaturalPerson => new NaturalPersonAttendee(
                dto.EventId,
                dto.Name,
                dto.PersonalIdCode,
                dto.PaymentMethodId,
                dto.AdditionalInfo,
                null
            ),
            AttendeeType.LegalEntity => new LegalEntityAttendee(
                dto.EventId,
                dto.LegalName,
                dto.CompanyRegistrationCode,
                dto.AttendeeCount,
                dto.PaymentMethodId,
                dto.AdditionalInfo,
                dto.ParticipantRequests,
                null
            ),
            _ => throw new ArgumentException("Invalid attendee type")
        };
    }

    public static AttendeeDto ToDto(this Attendee attendee)
    {
        return new AttendeeDto
        {
            Id = attendee.AttendeeId,
            Name = attendee.Name,
            PaymentMethod = attendee.PaymentMethod,
            AdditionalInfo = attendee.AdditionalInfo,
            ParticipantRequests = attendee is LegalEntityAttendee legalAttendee ? legalAttendee.ParticipantRequests?.ToString() ?? string.Empty : string.Empty,
        };
    }
}
