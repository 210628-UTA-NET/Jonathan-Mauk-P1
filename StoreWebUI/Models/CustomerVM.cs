using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
using System.ComponentModel.DataAnnotations;

namespace StoreWebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        {

        }

        public CustomerVM(Customer p_customer)
        {
            CustomerId = p_customer.CustomerId;
            Name = p_customer.Name;
            Address = p_customer.Address;
            Email = p_customer.Email;
            PhoneNumber = p_customer.PhoneNumber;
            CustomerOrders = new List<OrderVM>();
        }

        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber{ get; set; }

        public IEnumerable<OrderVM> CustomerOrders { get; set; }
    }
}
