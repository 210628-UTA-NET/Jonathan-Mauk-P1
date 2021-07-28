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
            List<OrderVM>  temp = new List<OrderVM>();
            foreach (Orders item in p_customer.Orders)
            {
                temp.Add(new OrderVM(item, item.StoreFrontId.ToString(), p_customer.Name));
            }
            CustomerOrders = temp;
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
