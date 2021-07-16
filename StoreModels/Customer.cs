using System;
using System.Collections.Generic;

namespace StoreModels 
{
    public class Customer 
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Orders> Orders { get; set; }
        public Customer()
        {
            
        }
        public Customer(string name, string address, string email, string phone)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phone;
        }

        public override string ToString()
        {
            return Name + ", " + Address + ", " + Email + ", " + PhoneNumber;
        }
    }
}