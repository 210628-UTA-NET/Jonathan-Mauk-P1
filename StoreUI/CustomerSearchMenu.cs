using System;
using System.Collections.Generic;
using StoreModels;
using StoreAppBL;

namespace StoreUI
{
    class CustomerSearchMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();
            System.Console.WriteLine(@"
               _____                      __          
              / ___/___  ____ ___________/ /_         
              \__ \/ _ \/ __ `/ ___/ ___/ __ \        
             ___/ /  __/ /_/ / /  / /__/ / / /        
   ______   /____/\___/\__,_/_/   \___/_/ /_/         
  / ____/_  _______/ /_____  ____ ___  ___  __________
 / /   / / / / ___/ __/ __ \/ __ `__ \/ _ \/ ___/ ___/
/ /___/ /_/ (__  ) /_/ /_/ / / / / / /  __/ /  (__  ) 
\____/\__,_/____/\__/\____/_/ /_/ /_/\___/_/  /____/  
                                                      ");
            System.Console.WriteLine("[2] Search a customer by Id.");
            System.Console.WriteLine("[1] Search a customer by name.");
            System.Console.WriteLine("[0] Return to Customer Options.");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions val = MenuOptions.SearchCustomer;
            switch (info)
            {
                case "0":
                    val = MenuOptions.CustomerOptions;
                    break;
                case "1":
                    Customer customer = SearchCustomerByName();
                    if (customer != null)
                    {
                        ListCustomer(customer);
                    }
                    else
                    {
                        Console.WriteLine("Customer could not be found.");        
                    }
                    EnterToContinue();
                    break;
                case "2":
                    SearchCustomerById();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood.");
                    EnterToContinue();
                    break;
            }
            return val;
        }

        public Customer SearchCustomerByName()
        {
            Console.WriteLine("Please enter the customer's name.");
            string name = Console.ReadLine();
            List<Customer> foundCustomers = CustomerBL.SearchForCustomers(name);
            Customer customer = null;
            if (foundCustomers.Count == 0)
            {
                customer = null;
            }
            else if (foundCustomers.Count == 1)
            {
                customer = foundCustomers[0];
            }
            else
            {
                customer = ChooseCustomer(foundCustomers);
            }
            return customer;
        }

        private void SearchCustomerById()
        {
            Console.WriteLine("Enter the Customer's Id.");
            string id = Console.ReadLine();
            try
            {
                Customer customer = CustomerBL.SearchCustomer(Int32.Parse(id));
                if (customer != null)
                {
                    ListCustomer(customer);
                }
                else
                {
                    Console.WriteLine("Customer could not be found.");
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Input could not be understood.");
            }
            EnterToContinue();
        }

        private Customer ChooseCustomer(List<Customer> p_customers)
        {
            Customer found = null;
            while (found == null)
            {
                Console.Clear();
                Console.WriteLine("Choose the correct customer.");
                foreach (Customer customer in p_customers)
                {
                    Console.WriteLine($"[{customer.CustomerId}] Name: {customer.Name}\tEmail: {customer.Email}");
                }
                string input = Console.ReadLine();
                try
                {
                    found = CustomerBL.SearchCustomer(Int32.Parse(input));
                }
                catch (System.Exception) { }
            }
            return found;
        }

        private void ListCustomer(Customer customer)
        {
            Console.Clear();
            System.Console.WriteLine("==============================");
            System.Console.WriteLine($"Name: {customer.Name}");
            System.Console.WriteLine($"Address: {customer.Address}");
            System.Console.WriteLine($"Email: {customer.Email}");
            System.Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
            System.Console.WriteLine("==============================");
        }
    }
}