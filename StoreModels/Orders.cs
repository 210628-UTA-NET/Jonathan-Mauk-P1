using System;
using System.Collections.Generic;

namespace StoreModels
{
    public class Orders
    {
        public int Id { get; set; }
        public List<OrderLineItem> LineItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int StoreFrontId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOrdered { get; set; }

        public Orders()
        {
            
        }
    }
}