using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class OrderDL : Repository, IOrderDL
    {
        // The Singleton for the OrderDL class
        public static OrderDL _orderDL = new OrderDL(new StoreAppDBContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderDL(StoreAppDBContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        /// <summary>
        /// Converts an Entities.Order class to a StoreModels.Orders class
        /// </summary>
        /// <param name="eOrder">The Entities.Order to be converted</param>
        /// <returns>A converted StoreModels.Orders class</returns>
        public static Orders EntityToModel(Orders eOrder)
        {
            return new Orders();
            // {
            //     Id = eOrder.OrderId,
            //     LineItems = OrderLineItemDL._orderLineItem.RetrieveLineItems(eOrder.OrderId),
            //     TotalPrice = (decimal)eOrder.TotalPrice,
            //     LocationId = eOrder.StoreId,
            //     CustomerId = eOrder.CustomerId
            // };
        }

        public Orders FindOrder(int orderID)
        {
            Orders order = _context.Orders.Find(orderID);
            return order;
        }

        public List<Orders> FindOrdersByCustomer(int p_customerID)
        {
            return _context.Orders.Select(
                rest => rest
            ).ToList().Where(
                rest => rest.CustomerId == p_customerID
            ).ToList();
        }

        public List<Orders> FindOrdersByStore(int p_storeID)
        {
            return _context.Orders.Select(
                rest => rest
            ).ToList().Where(
                rest => rest.LocationId == p_storeID
            ).ToList();
        }

        public bool PlaceOrder(Orders order, List<LineItems> p_changedLineItems)
        {
            bool val = false;
            try
            {
                // Update the StoreLineItems to match the order being made
                foreach (LineItems item in p_changedLineItems)
                {
                    StoreLineItemDL._storeLineItem.UpdateLineItemNoSave(item.Id, -item.Count);
                }
                // Add the order to the database
                _context.Orders.Add(order);

                // Add the OrderLineItems to the database
                foreach (OrderLineItem item in order.LineItems)
                {
                    // Passing in the created order allows for the OrderLineItems to 
                    // get the Order's OrderId value
                    OrderLineItemDL._orderLineItem.AddLineItem(item, order);
                }
                _context.SaveChanges();     // Save Changes to the database
                StoreLineItemDL._storeLineItem.StoreLineItemSave(); //Makes sure that the Store line items are updated
                val = true;
            }
            // Catch any errors and return false to signal a failure
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }
    }
}