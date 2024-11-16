using api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Application.DTOs
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfTypeAttribute : ValidationAttribute
    {
        private readonly AttendeeType _requiredType;

        public RequiredIfTypeAttribute(AttendeeType requiredType)
        {
            _requiredType = requiredType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var typeProperty = validationContext.ObjectType.GetProperty("Type");

            if (typeProperty == null)
            {
                return new ValidationResult($"Type property not found on {validationContext.ObjectType.Name}");
            }

            var typeValue = typeProperty.GetValue(instance);
            if (typeValue is AttendeeType attendeeType && attendeeType == _requiredType)
            {
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                {
                    return new ValidationResult($"The {validationContext.MemberName} field is required for {attendeeType}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
