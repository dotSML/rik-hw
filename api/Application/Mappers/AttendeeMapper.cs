using api.Application.DTOs;
using api.Application.Mappers;
using api.Domain.Enums;
using api.Domain.Models;

public static class AttendeeMapper
{
    public static Attendee ToModelFromDto(this AttendeeDto dto)
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
                dto.AttendeeCount ?? 0,
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

    public static Attendee MergeUpdateDtoIntoEntity(this UpdateAttendeeDto dto, Attendee entity)   
    {
        if (!string.IsNullOrEmpty(dto.FirstName) && entity is NaturalPersonAttendee naturalAttendee)
            naturalAttendee.UpdateFirstName(dto.FirstName);

        if (!string.IsNullOrEmpty(dto.LastName) && entity is NaturalPersonAttendee naturalPerson)
            naturalPerson.UpdateLastName(dto.LastName);

        if (!string.IsNullOrEmpty(dto.PersonalIdCode) && entity is NaturalPersonAttendee naturalPersonEntity)
            naturalPersonEntity.UpdatePersonalIdCode(dto.PersonalIdCode);

        if (!string.IsNullOrEmpty(dto.LegalName) && entity is LegalEntityAttendee legalAttendee)
            legalAttendee.UpdateLegalName(dto.LegalName);

        if (!string.IsNullOrEmpty(dto.CompanyRegistrationCode) && entity is LegalEntityAttendee legalEntityPerson)
            legalEntityPerson.UpdateCompanyRegistrationCode(dto.CompanyRegistrationCode);

        if (dto.AttendeeCount.HasValue && entity is LegalEntityAttendee legalEntityAttendee)
            legalEntityAttendee.UpdateAttendeeCount(dto.AttendeeCount.Value);

        if (!string.IsNullOrEmpty(dto.ParticipantRequests) && entity is LegalEntityAttendee legalAttendeeEntity)
            legalAttendeeEntity.UpdateParticipantRequests(dto.ParticipantRequests);

        if (dto.PaymentMethodId.HasValue)
            entity.UpdatePaymentMethodId(dto.PaymentMethodId.Value);

        if (!string.IsNullOrEmpty(dto.AdditionalInfo))
            entity.UpdateAdditionalInfo(dto.AdditionalInfo);

        return entity;
    }


    public static AttendeeDto ToDto(this Attendee attendee)
    {
        var dto = new AttendeeDto
        {
            Id = attendee.AttendeeId,
            PaymentMethodId = attendee.PaymentMethodId,
            PaymentMethod = attendee.PaymentMethod,
            AdditionalInfo = attendee.AdditionalInfo,
            FirstName = string.Empty,
            LastName = string.Empty,
            LegalName = string.Empty,
            ParticipantRequests = string.Empty,
            EventId = attendee.EventId,
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
            dto.AttendeeCount = legalAttendee.AttendeeCount;
        }

        return dto;
    }

}
