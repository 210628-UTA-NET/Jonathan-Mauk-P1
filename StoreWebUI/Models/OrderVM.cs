using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {

        }

        public OrderVM(Orders p_order)
        {
            Id = p_order.Id;
            TotalPrice = p_order.TotalPrice;
            LocationId = p_order.LocationId;
            CustomerId = p_order.CustomerId;
        }

        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
    }
}
