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

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EstonianIdCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           
            if (value == null || value == "")
            {
                return ValidationResult.Success;
            }


            if (value != null && value is string idCode && !IsValidEstonianIdCode(idCode))
            {
                return new ValidationResult("Isikukood on vigane");
            }

            return ValidationResult.Success;
        }

        private bool IsValidEstonianIdCode(string idCode)
        {
            if (idCode.Length != 11 || !long.TryParse(idCode, out _))
            {
                return false;
            }

            int[] weightsFirstRound = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int[] weightsSecondRound = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

            int[] digits = Array.ConvertAll(idCode.ToCharArray(), c => c - '0');

            int checksum = 0;
            for (int i = 0; i < 10; i++)
            {
                checksum += digits[i] * weightsFirstRound[i];
            }
            checksum %= 11;

            if (checksum == 10)
            {
                checksum = 0;
                for (int i = 0; i < 10; i++)
                {
                    checksum += digits[i] * weightsSecondRound[i];
                }
                checksum %= 11;
            }

            return checksum != 10 && checksum == digits[10];
        }
    }
}
