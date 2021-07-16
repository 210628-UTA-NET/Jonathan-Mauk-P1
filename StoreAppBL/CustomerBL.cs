using System;
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    /// <summary>
    /// Responsible for calling any Customer Data Layer methods
    /// </summary>
    public class CustomerBL
    {
        /// <summary>
        /// Creates a new Customer to add to the database
        /// </summary>
        /// <param name="name">The name of the new Customer</param>
        /// <param name="address">The address of the new Customer</param>
        /// <param name="email">The email of the new Customer</param>
        /// <param name="phone">The phone number of the new Customer</param>
        /// <returns>True if the Customer was sucessfully added</returns>
        public static bool AddCustomer(string name, string address, string email, string phone)
        {
            Customer custo = new Customer(name, address, email, phone);
            return CustomerDL._customerDL.AddCustomer(custo);
        }

        /// <summary>
        /// Calls the data layer to find a list of customers given the name of the customer.
        /// </summary>
        /// <param name="name">The name of the Customer</param>
        /// <returns>The List of Customers matching name found or null if none are found</returns>
        public static List<Customer> SearchForCustomers(string name)
        {
            return CustomerDL._customerDL.FindCustomers(name);
        }

        /// <summary>
        /// Calls the data layer to find a customer given the id of the customer
        /// </summary>
        /// <param name="id">The id of the Customer</param>
        /// <returns>The Customer found or null if not found</returns>
        public static Customer SearchCustomer(int id)
        {
            return CustomerDL._customerDL.FindCustomer(id);
        }

        /// <summary>
        /// Calls the data layer to retrieve a list of all Customers
        /// </summary>
        /// <returns>a list containing every customer in the database</returns>
        public static List<Customer> ListCustomers()
        {
            return CustomerDL._customerDL.RetrieveCustomers();
        }
    }
}
