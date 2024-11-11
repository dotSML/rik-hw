using api.Application.DTOs;
using api.Domain.Entities;
using api.Domain.Enums;

public static class AttendeeMapper
{
    public static Attendee ToAttendeeFromCreate(this CreateAttendeeDto dto)
    {
        return dto.Type switch
        {
            AttendeeType.NaturalPerson => new NaturalPersonAttendee(
                dto.Name,
                dto.PersonalIdCode,
                dto.PaymentMethod,
                dto.AdditionalInfo,
                dto.ParticipantRequests
            ),
            AttendeeType.LegalEntity => new LegalEntityAttendee(
                dto.LegalName,
                dto.CompanyRegistrationCode,
                dto.AttendeeCount,
                dto.PaymentMethod,
                dto.AdditionalInfo,
                dto.ParticipantRequests
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
            ParticipantRequests = attendee.ParticipantRequests
        };
    }
}
