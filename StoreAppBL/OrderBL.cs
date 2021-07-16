using System;
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    public class OrderBL
    {
        // The Order currently being constructed
        public Orders CurrentOrder { get; set; }
        
        // The Store the Order is being ordered from
        public StoreFront CurrentStore { get; set; }
        
        // A list of LineItems that contain information of StoreLineItems being ordered
        // and the quantity of StoreLineItems being ordered
        private List<LineItems> _changedStoreLineItems = new List<LineItems>();

        /// <summary>
        /// The Constructor for the class
        /// </summary>
        public OrderBL()
        {
            CurrentOrder = new Orders();
        }

        public static Orders FindOrder(int id)
        {
            return OrderDL._orderDL.FindOrder(id);
        }

        /// <summary>
        /// Begins the process of making an order.
        /// </summary>
        /// <param name="p_customer">The Customer object of the customer making the order</param>
        /// <param name="p_storeFront">The StoreFront object of the storefront where the order is being ordered from</param>
        public void BeginOrder(Customer p_customer, StoreFront p_storeFront)
        {
            CurrentOrder.LocationId = p_storeFront.Id;
            CurrentOrder.TotalPrice = 0;
            CurrentOrder.CustomerId = p_customer.CustomerId;
            CurrentOrder.LineItems = new List<OrderLineItem>();
            CurrentStore = p_storeFront;
        }

        /// <summary>
        /// Creates a LineItem and adds it to the CurrentOrder.
        /// Checks to make sure that there is enough inventory to order the LineItem.
        /// </summary>
        /// <param name="p_id">The Id of the StoreLineItem that the customer wants to order from</param>
        /// <param name="num">The amount of product the customer wants from the LineItem.
        /// Cannot be less than 0.</param>
        /// <returns>True: If the LineItem was successfully created 
        /// False: If the LineItem could not be made</returns>
        public bool AddOrderItem(int p_id, int num)
        {
            LineItems storeLineItem = StoreLineItemDL._storeLineItem.FindLineItem(p_id);
            OrderLineItem orderLineItem = null;
            bool val = false;

            // Check to see if product is already being ordered
            foreach (OrderLineItem item in CurrentOrder.LineItems)
            {
                if (item.Product.Id == storeLineItem.Product.Id)
                {
                    orderLineItem = item;
                }
            }

            // Check to see if there is enough product to be ordered
            if(num > storeLineItem.Count)
            {
                val = false;
            }
            // 
            else if (orderLineItem != null)
            {
                if (orderLineItem.Count + num > storeLineItem.Count)
                {
                    val = false;
                }
                else
                {
                    orderLineItem.Count += num;
                    CurrentOrder.TotalPrice += orderLineItem.Product.Price * num;
                    val = true;
                }
            }
            else
            {
                orderLineItem = new OrderLineItem()
                {
                    Product = storeLineItem.Product,
                    Count = num
                };
                CurrentOrder.LineItems.Add(orderLineItem);
                CurrentOrder.TotalPrice += orderLineItem.Product.Price * num;
                val = true;
            }

            if (val)
            {
                _changedStoreLineItems.Add(new LineItems(){
                    Id = p_id,
                    Count = num
                });
            }
            return val;
        }

        public void IsChoice(int choice)
        {
            foreach (LineItems item in CurrentStore.Inventory)
            {
                if (item.Id == choice)
                {
                    return;
                }
            }
            throw new Exception();
        }

        public bool FinalizeOrder()
        {
            if (CurrentOrder.TotalPrice <= 0)
            {
                return false;
            }
            return OrderDL._orderDL.PlaceOrder(CurrentOrder, _changedStoreLineItems);
        }
    }
}