using System;
using StoreModels;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace StoreAppData
{
    // Consider changing to Singleton instead of making every function static
    public class CustomerDL : Repository, ICustomerDL
    {
        // Singleton for CustomerDL
        public static CustomerDL _customerDL = new CustomerDL(new StoreAppDBContext(DatabaseConnection.GetDatabaseOptions()));

        public CustomerDL(StoreAppDBContext p_context) : base(p_context)
        {
            _context = p_context;
        }
        public bool AddCustomer(Customer item)
        {
            bool val = false;
            try
            {
                _context.Customers.Add(item);
                _context.SaveChanges();
                val = true;

            }
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }

        /// <summary>
        /// Converts an Entities.Customer class to a StoreModels.Customer class
        /// </summary>
        /// <param name="eCustomer">The Entities.Customer to be converted</param>
        /// <returns>A converted StoreModels.Customer class</returns>
        /*public static Customer EntityToModel(Customer eCustomer)
        {
            return new Customer()
            {
                CustomerId = eCustomer.CustomerId,
                Name = eCustomer.CustomerName,
                Address = eCustomer.CustomerAddress,
                Email = eCustomer.Email,
                PhoneNumber = eCustomer.PhoneNumber,
                Orders = OrderDL._orderDL.FindOrdersByCustomer(eCustomer.CustomerId)
            };
        }*/

        public StoreModels.Customer FindCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public List<StoreModels.Customer> FindCustomers(string name)
        {
            return _context.Customers.Select(
                rest => rest
            ).ToList().Where(
                rest => rest.Name.Contains(name)
            ).ToList().OrderBy(
                o => o.CustomerId
            ).ToList();
        }

        public List<StoreModels.Customer> RetrieveCustomers()
        {
            return _context.Customers.Select(
                rest => rest
            ).ToList();
        }
    }
}