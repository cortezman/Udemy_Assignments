using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ModelsAssignment.Models
{
    public class Order : IValidatableObject
    {
        public List<Product> product { get; set; } = new List<Product>();

        [BindNever]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "Order Date can't be blank")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Required]
        public double InvoicePrice { get; set; }

        public double TotalPrice()
        {
            double TotalPrice = 0;
            
            foreach (Product p in product) 
            {
                TotalPrice += (p.Price* p.Quantity);
            }

            return TotalPrice;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double invoiceprice = InvoicePrice;
            double totalPrice = TotalPrice();
            
            if (invoiceprice != totalPrice)
            {
                yield return new ValidationResult("Invoice Price should be equal to the total cost of all products in the order");
            }

            if (OrderDate < Convert.ToDateTime("2000-01-01"))
            {
                yield return new ValidationResult("Order date should be greater than or equal to 2000-01-01.");
            }
        }
    }
}
