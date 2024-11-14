using api.Application.DTOs;
using api.Application.Mappers;
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
                dto.FirstName,
                dto.LastName,
                dto.PersonalIdCode,
                dto.PaymentMethodId,
                dto.AdditionalInfo,
                null,
                null,
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
                null,
                null,
                null
            ),
            _ => throw new ArgumentException("Invalid attendee types")
        };
    }

    public static AttendeeDto ToDto(this Attendee attendee)
    {
        var dto = new AttendeeDto
        {
            Id = attendee.AttendeeId,
            PaymentMethod = attendee.PaymentMethod,
            AdditionalInfo = attendee.AdditionalInfo,
            FirstName = string.Empty,
            LastName = string.Empty,
            LegalName = string.Empty,
            ParticipantRequests = string.Empty,
            Event = attendee.Event?.ToDto(),
            Type = attendee.GetType() == typeof(NaturalPersonAttendee) ? AttendeeType.NaturalPerson : AttendeeType.LegalEntity,
        };

        if (attendee is NaturalPersonAttendee naturalAttendee)
        {
            dto.FirstName = naturalAttendee.FirstName;
            dto.LastName = naturalAttendee.LastName;
            dto.PersonalIdCode = naturalAttendee.PersonalIdCode;
        }
        else if (attendee is LegalEntityAttendee legalAttendee)
        {
            dto.LegalName = legalAttendee.LegalName;
            dto.CompanyRegistrationCode = legalAttendee.CompanyRegistrationCode;
            dto.ParticipantRequests = legalAttendee.ParticipantRequests?.ToString() ?? string.Empty;
        }

        return dto;
    }

}
