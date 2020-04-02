using System;
using System.ComponentModel.DataAnnotations;

namespace SparkEquation.Trial.WebAPI.Data.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateValidationAttribute : ValidationAttribute
    {
        public int ExpirationPeriodDays { get; set; }
        public string ValidationErrorMessage => "Expiration date expires less than 30 days since now";

        public ExpirationDateValidationAttribute(int expirationPeriodDays)
        {
            this.ExpirationPeriodDays = expirationPeriodDays;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var expiryDate = (DateTime)value;

            if (expiryDate < DateTime.Now.Date.AddDays(30))
                return new ValidationResult(ErrorMessage ?? ValidationErrorMessage);

            return ValidationResult.Success;
        }
    }
}
