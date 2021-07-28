using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class OrderLineItemVM
    {
        public OrderLineItemVM()
        {

        }

        public OrderLineItemVM(OrderLineItem p_orderLineItem)
        {
            Id = p_orderLineItem.Id;
            OrderId = p_orderLineItem.FkId;
            Count = p_orderLineItem.Count;
            ProductName = p_orderLineItem.Product.Name;
            ProductPrice = p_orderLineItem.Product.Price;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public string ProductName{ get; set; }
        public decimal ProductPrice { get; set; }

    }
}
