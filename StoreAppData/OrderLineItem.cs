using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class OrderLineItemDL : Repository, ILineItemDL
    {
        // The Singleton for the OrderLineItem class
        public static OrderLineItemDL _orderLineItem = new OrderLineItemDL(new StoreAppDBContext(DatabaseConnection.GetDatabaseOptions()));
        public OrderLineItemDL(StoreAppDBContext p_context) : base(p_context)
        {
            _context = p_context;
        }
        public void ChangeContext(StoreAppDBContext p_context)
        {
            _context = p_context;
        }

        public LineItems FindLineItem(int id)
        {
            OrderLineItem orderLineItem = _context.OrderLineItems.Find(id);
            return orderLineItem;
        }

        public List<LineItems> RetrieveLineItems(int fkid)
        {
            return _context.OrderLineItems.Select(
                rest => rest as LineItems
            ).ToList().Where(
                rest => rest.FkId == fkid
            ).ToList();
        }

        /// <summary>
        /// Adds an OrderLineItem to the database
        /// </summary>
        /// <param name="lineItem">The Lineitem to be added</param>
        /// <param name="order">The Order that the OrderLineItem corresponds to</param>
        /// <returns>True if the OrderLineItem was successfully added to the database</returns>
        public bool AddLineItem(OrderLineItem lineItem, Orders order)
        {
            bool val = false;
            try
            {
                _context.OrderLineItems.Add(
                    new OrderLineItem()
                    {
                        Product = lineItem.Product,
                        Count = lineItem.Count,
                        //Order = order   // This allows for the OrderLineItem to get the primary key of the Order and use it as a foreign key
                    }
                );
                val = true;
            }
            catch (System.Exception)
            {
                val = false;
            }
            return val;
        }

        /// <summary>
        /// Converts an Entities.OrderLineItem class to a StoreModels.LineItems class
        /// </summary>
        /// <param name="eLineItem">The Entities.OrderLineItem to be converted</param>
        /// <returns>A converted StoreModels.LineItems class</returns>
        // public static LineItems EntityToModel(Entities.OrderLineItem eLineItem)
        // {
        //     return new LineItems(){
        //         Id = eLineItem.OrderLineItemId,
        //         FkId = eLineItem.OrderId,
        //         Product = ProductDL._productDL.FindProduct(eLineItem.ProductId),
        //         Count = eLineItem.Quantity
        //     };
        // }
    }
}