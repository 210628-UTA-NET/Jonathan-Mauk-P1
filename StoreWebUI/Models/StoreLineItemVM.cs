using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class StoreLineItemVM
    {
        public StoreLineItemVM()
        {

        }

        public StoreLineItemVM(StoreLineItem p_storeLineItem)
        {
            Id = p_storeLineItem.Id;
            StoreId = p_storeLineItem.FkId;
            Count = p_storeLineItem.Count;
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int Count { get; set; }

    }
}
