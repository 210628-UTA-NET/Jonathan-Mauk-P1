using System;
using System.Collections.Generic;

namespace StoreModels 
{
    public class StoreFront 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<StoreLineItem> Inventory { get; set; }
        public List<Orders> Orders { get; set; }
        public StoreFront()
        {
            
        }
    }
}
