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

        public OrderVM(Orders p_order, string p_storeName, string p_customerName)
        {
            Id = p_order.Id;
            TotalPrice = p_order.TotalPrice;
            LocationId = p_order.StoreFrontId;
            CustomerId = p_order.CustomerId;
            StoreName = p_storeName;
            CustomerName = p_customerName;
            List<OrderLineItemVM> temp = new List<OrderLineItemVM>();
            foreach (OrderLineItem item in p_order.LineItems)
            {
                temp.Add(new OrderLineItemVM(item));
            }
            OrderLineItems = temp;
        }

        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int LocationId { get; set; }
        public string StoreName{ get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<OrderLineItemVM> OrderLineItems { get; set; }
    }

    public class CreateOrderFromCustomerVM
    {
        public CreateOrderFromCustomerVM()
        {
            Customer = new CustomerVM();
            Stores = new List<StoreFrontDetailsVM>();
            ChosenStore = null;
        }

        public CreateOrderFromCustomerVM(Customer p_customer, List<StoreFront> p_stores)
        {
            Customer = new CustomerVM(p_customer);
            List<StoreFrontDetailsVM> temp= new List<StoreFrontDetailsVM>();
            foreach (StoreFront store in p_stores)
            {
                temp.Add(new StoreFrontDetailsVM(store, store.Inventory));
            }
            Stores = temp;
            ChosenStore = null;
        }
        public CreateOrderFromCustomerVM(Customer p_customer, StoreFront p_chosenStore, List<StoreFront> p_stores)
        {
            Customer = new CustomerVM(p_customer);
            ChosenStore = new StoreFrontDetailsVM(p_chosenStore, p_chosenStore.Inventory);
            List<StoreFrontDetailsVM> temp = new List<StoreFrontDetailsVM>();
            foreach (StoreFront store in p_stores)
            {
                temp.Add(new StoreFrontDetailsVM(store, store.Inventory));
            }
            Stores = temp;
        }

        public IEnumerable<StoreFrontDetailsVM> Stores { get; set; }
        public CustomerVM Customer { get; set; }
        public StoreFrontDetailsVM ChosenStore { get; set; }
    }
}
