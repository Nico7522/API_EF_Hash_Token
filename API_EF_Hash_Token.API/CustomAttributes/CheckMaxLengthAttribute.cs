using System.ComponentModel.DataAnnotations;

namespace API_EF_Hash_Token.API.CustomAttributes
{
    public class CheckMaxLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Required");

            if (value?.ToString().Length < 9 || value?.ToString().Length > 9) return new ValidationResult("Invalid phone number");
            return ValidationResult.Success;

            
        }

    
    }
}
