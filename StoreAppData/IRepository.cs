using System;
using StoreModels;
using System.Collections.Generic;

namespace StoreAppData
{
    /// <summary>
    /// Base class for all of the data layer classes.
    /// Adds the _context variable for getting the database context
    /// </summary>
    public abstract class Repository
    {
        protected StoreAppDBContext _context;
        /// <summary>
        /// Constructs a data layer class
        /// </summary>
        /// <param name="p_context">This should be the context for the database</param>
        public Repository(StoreAppDBContext p_context) {  }
    }

    /// <summary>
    /// Responsible for accessing the Customer table of the database
    /// </summary>
    public interface ICustomerDL
    {
        /// <summary>
        /// Finds a list of Customers from the database given a name 
        /// </summary>
        /// <returns>A list of customers containing the name being searched for</returns>
        List<Customer> FindCustomers(string name);

        /// <summary>
        /// Finds a customer from the database
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns>The Customer being searched for</returns>
        Customer FindCustomer(int id);

        /// <summary>
        /// Retrieves all Customers from the database
        /// </summary>
        /// <returns>A list of all Customers in the database</returns>
        List<Customer> RetrieveCustomers();

        /// <summary>
        /// Add a Customer to the database
        /// </summary>
        /// <param name="item">The Customer to be added to the database</param>
        /// <returns>True if the Customer was successfully added</returns>
        bool AddCustomer(Customer item);
    }

    /// <summary>
    /// Responsible for accessing the StoreFront table in the database
    /// </summary>
    public interface IStoreFrontDL
    {
        /// <summary>
        /// Finds a store based upon the name given
        /// </summary>
        /// <param name="name">The name of the store to be found</param>
        /// <returns>The Store object that is being searched for</returns>
        StoreFront FindStore(string name);
        /// <summary>
        /// Finds a store based upon the id given
        /// </summary>
        /// <param name="id">The id of the store to be found</param>
        /// <returns>The Store object that is being searched for</returns>
        StoreFront FindStore(int id);

        /// <summary>
        /// Retrieves a List of all stores.
        /// </summary>
        /// <returns>A list containing all of the storefronts</returns>
        List<StoreFront> RetrieveStoreFronts();
    }

    /// <summary>
    /// Responsible for accessing the Products table in the database
    /// </summary>
    public interface IProductDL
    {
        /// <summary>
        /// Finds a Product based upon the id given
        /// </summary>
        /// <param name="id">The product id</param>
        /// <returns>The product that matches the id given</returns>
        Products FindProduct(int id);

        /// <summary>
        /// Retrieves a list of all products stored on the database
        /// </summary>
        /// <returns>List containing all products stored on the database</returns>
        List<Products> RetrieveProducts();
    }

    /// <summary>
    /// Responsible for accessing the StoreLineItems and the OrderLineItems from the database
    /// </summary>
    public interface ILineItemDL
    {
        /// <summary>
        /// Finds a LineItem based upon the id given
        /// </summary>
        /// <param name="id">The LineItem id</param>
        /// <returns>The LineItem that matches the id given</returns>
        LineItems FindLineItem(int id);

        /// <summary>
        /// Finds all LineItems belonging to a specified foreign key
        /// </summary>
        /// <param name="fkid">The id number of the foreign key</param>
        /// <returns>The List of LineItems that correspond to the given foreign key</returns>
        List<LineItems> RetrieveLineItems(int fkid);
    }

    /// <summary>
    /// Responsible for accessing the Order Table of the database
    /// </summary>
    public interface IOrderDL
    {
        /// <summary>
        /// Retrieves all Orders belonging to a specified Customer.
        /// </summary>
        /// <param name="p_customerID">The Customer Id that all of the orders belong to</param>
        /// <returns>A list of orders belonging to the customer that matches p_customerID</returns>
        List<Orders> FindOrdersByCustomer(int p_customerID);

        /// <summary>
        /// Retrieves all Orders belonging to a specified store
        /// </summary>
        /// <param name="p_storeID">The id of the store that all of the orders belong to</param>
        /// <returns>A list of orders that belong to the specified store</returns>
        List<Orders> FindOrdersByStore(int p_storeID);

        /// <summary>
        /// Adds an order to the database and updates the store line items to reflect
        /// items being ordered
        /// </summary>
        /// <param name="order">The order that is to be added to the database</param>
        /// <param name="p_Changed">A list of LineItems that contain the id of the StoreLineItem being ordered
        /// and the quantity of items being ordered from that StoreLineItem.</param>
        /// <returns>True if the order was added to the database.</returns>
        bool PlaceOrder(Orders order, List<LineItems> p_Changed);

        /// <summary>
        /// Finds an order
        /// </summary>
        /// <param name="orderID">The id of the order to be found</param>
        /// <returns>The Order object being searched for</returns>
        Orders FindOrder(int orderID);
    }
}
