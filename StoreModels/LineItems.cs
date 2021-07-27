using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreModels
{
    public class LineItems
    {
        public int Id { get; set; }
        [NotMapped]
        public virtual int FkId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public virtual Products Product { get; set; }
        public LineItems()
        {
            
        }

        public override string ToString()
        {
            return $"Name: {Product.Name}\t Price: ${Product.Price}\t Quantity: {Count}";
        }
    }

    public class OrderLineItem : LineItems
    {
        public int OrdersId { get; set; }
        public OrderLineItem() : base()
        {
            
        }
        [NotMapped]
        public override int FkId { get => OrdersId; set => OrdersId = value; }
    }

    public class StoreLineItem : LineItems
    {
        public int StoreFrontId { get; set; }
        public StoreLineItem() : base()
        {
            
        }
        [NotMapped]
        public override int FkId { get => StoreFrontId; set => StoreFrontId = value; }
    }
}