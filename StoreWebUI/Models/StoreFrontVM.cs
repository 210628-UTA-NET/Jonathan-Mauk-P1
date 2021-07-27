using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class StoreFrontVM
    {
        public StoreFrontVM()
        {

        }

        public StoreFrontVM(StoreFront p_store)
        {
            Id = p_store.Id;
            Name = p_store.Name;
            Address = p_store.Address;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }

    public class StoreFrontDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<StoreLineItemVM> LineItemVMs { get; set; }

        public StoreFrontDetailsVM()
        {

        }

        public StoreFrontDetailsVM(StoreFront p_storeFront, List<LineItems> p_storeLineItems)
        {
            Id = p_storeFront.Id;
            Name = p_storeFront.Name;
            Address = p_storeFront.Address;
            List<StoreLineItemVM> tempList = new List<StoreLineItemVM>();
            foreach (StoreLineItem item in p_storeLineItems)
            {
                tempList.Add(new StoreLineItemVM(item));
            }
            LineItemVMs = tempList;
        }
        public StoreFrontDetailsVM(StoreFront p_storeFront, List<StoreLineItem> p_storeLineItems)
        {
            Id = p_storeFront.Id;
            Name = p_storeFront.Name;
            Address = p_storeFront.Address;
            List<StoreLineItemVM> tempList = new List<StoreLineItemVM>();
            foreach (StoreLineItem item in p_storeLineItems)
            {
                tempList.Add(new StoreLineItemVM(item));
            }
            LineItemVMs = tempList;
        }
    }
}
