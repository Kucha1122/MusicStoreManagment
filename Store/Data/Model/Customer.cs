using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Model
{
    public class Customer
    {
        public int CustomerId { get; protected set; }
        [Required(ErrorMessage = "User name is required."),MinLength(3), MaxLength(50)]
        public string CustomerName { get; protected set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string CustomerLastName { get; protected set; }
        [Required(ErrorMessage = "Password is required."),DataType(DataType.Password)]
        public string Password { get; protected set; }
        [Required(ErrorMessage = "Email is required!"),DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; protected set; }
        [Required(ErrorMessage = "Shipping address is required!")]
        public string ShippingAddress { get; protected set; }
    }
}
