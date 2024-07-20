using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            if(date <= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}