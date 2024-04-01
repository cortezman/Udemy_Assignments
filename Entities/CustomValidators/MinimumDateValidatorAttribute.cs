
using System.ComponentModel.DataAnnotations;


namespace Entities.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public DateTime MaxDate { get; set; } = Convert.ToDateTime("01/01/2000");
        public string DefaultErrorMessage { get; set; } = "Date should not be more than {0}";
        public MinimumDateValidatorAttribute() { }

        public MinimumDateValidatorAttribute(DateTime maxDate) { this.MaxDate = maxDate; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateTime = (DateTime)value;
                if (dateTime.Date < MaxDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MaxDate));
                }
                else { return ValidationResult.Success; }
            }
            return null;
        }

    }
}
