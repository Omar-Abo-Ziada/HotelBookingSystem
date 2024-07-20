using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystem.Core.Attributes
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            var propoerty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if(propoerty is null)
            {
                throw new ArgumentException("Property With this name not found .");
            }

            var comparisonValue = (DateTime)propoerty.GetValue(validationContext.ObjectInstance);

            if(currentValue <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}
