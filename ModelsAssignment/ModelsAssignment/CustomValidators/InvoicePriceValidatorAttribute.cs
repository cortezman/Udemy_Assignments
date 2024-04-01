using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ModelsAssignment.Models;

namespace ModelsAssignment.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        Order order = new Order();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double invoiceprice = order.InvoicePrice;
                double totalPrice = order.TotalPrice();
                
                if (invoiceprice != totalPrice)
                {
                    return new ValidationResult(ErrorMessage, new string[] { Convert.ToString(invoiceprice), validationContext.MemberName });
                }
                return null;
            }
            return null;
        }

    }
}
