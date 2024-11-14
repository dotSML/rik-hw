using api.Application.DTOs;
using api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class RequiredIfTypeAttribute : ValidationAttribute
{
    private readonly AttendeeType _requiredType;
    public RequiredIfTypeAttribute(AttendeeType requiredType)
    {
        _requiredType = requiredType;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dto = (CreateAttendeeDto)validationContext.ObjectInstance;

        if (dto.Type == _requiredType && value == null)
        {
            return new ValidationResult($"{validationContext.DisplayName} is required when Type is {_requiredType}.");
        }

        return ValidationResult.Success;
    }
}
