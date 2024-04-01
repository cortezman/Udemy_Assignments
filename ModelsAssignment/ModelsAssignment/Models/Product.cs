using System.ComponentModel.DataAnnotations;

namespace ModelsAssignment.Models
{
    public class Product : IValidatableObject
    {
        public int? ProductCode { get; set; }

        public double Price { get; set; }
        
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price <= 0)
            {
                yield return new ValidationResult("Product Price should be between a valid number");
            }

            if (Quantity <= 0)
            {
                yield return new ValidationResult("Product Quantity should be between a valid number");
            }

            if (string.IsNullOrEmpty(ProductCode.ToString()))
            {
                yield return new ValidationResult("Product Code should be supplied");
            }
        }
    }
}
