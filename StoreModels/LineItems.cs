using System;

namespace StoreModels
{
    public class LineItems
    {
        public int Id { get; set; }
        public virtual int FkId { get; set; }
        public Products Product { get; set; }
        public int Count { get; set; }
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
        private int _orderId;
        public OrderLineItem() : base()
        {
            
        }

        public override int FkId { get => _orderId; set => _orderId = value; }
    }

    public class StoreLineItem : LineItems
    {
        private int _storeId;
        public StoreLineItem() : base()
        {
            
        }

        public override int FkId { get => _storeId; set => _storeId = value; }
    }
}