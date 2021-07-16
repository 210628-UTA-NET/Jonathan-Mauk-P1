using System;
using StoreModels;
using StoreAppBL;
using System.Collections.Generic;

namespace StoreUI
{
    class ViewOrderMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(@"
       _    ___                   
      | |  / (_)__ _      __      
      | | / / / _ \ | /| / /      
      | |/ / /  __/ |/ |/ /       
   ___|___/_/\___/|__/|__/        
  / __ \_________/ /__  __________
 / / / / ___/ __  / _ \/ ___/ ___/
/ /_/ / /  / /_/ /  __/ /  (__  ) 
\____/_/   \__,_/\___/_/  /____/  
                                  ");
            Console.WriteLine("[2] View a customer's order history.");
            Console.WriteLine("[1] View a storefront's order history.");
            Console.WriteLine("[0] Return to Order Options.");
        }

        public MenuOptions YourChoice()
        {
            MenuOptions val = MenuOptions.ViewOrderHistory;
            string input = Console.ReadLine();
            string name;
            switch (input)
            {
                case "0":
                    val = MenuOptions.OrderOptions;
                    break;
                case "1":
                    Console.WriteLine("Enter the storefront's name.");
                    name = Console.ReadLine();
                    StoreFront store = StoreFrontBL._storeFrontBL.FindStore(name);
                    if (store != null)
                    {
                        if (store.Orders.Count != 0)
                        {
                            string repeat = "val";
                            while (repeat != "")
                            {
                                Console.Clear();
                                Console.WriteLine($"Store Name: {store.Name}\t Address: {store.Address}");
                                foreach (Orders order in store.Orders)
                                {
                                    Console.WriteLine($"[{order.Id}] Customer Id: {order.CustomerId} Total Price: ${order.TotalPrice}");
                                }
                                repeat = PickOrder();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The store {store.Name} has no orders.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The store could not be found.");
                    }
                    EnterToContinue();
                    break;
                case "2":
                    CustomerSearchMenu customerSearch = new CustomerSearchMenu();
                    Customer customer = customerSearch.SearchCustomerByName();
                    if (customer != null)
                    {
                        if (customer.Orders.Count != 0)
                        {
                            string repeat2 = "val";
                            while (repeat2 != "")
                            {
                                Console.Clear();
                                Console.WriteLine($"Customer Name: {customer.Name}\t Email: {customer.Email}");
                                foreach (Orders order in customer.Orders)
                                {
                                    Console.WriteLine($"[{order.Id}] Store Id: {order.LocationId} Total Price: ${order.TotalPrice}");
                                }
                                repeat2 = PickOrder();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The customer {customer.Name} has no orders.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("The customer could not be found.");
                    }
                    EnterToContinue();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood");
                    EnterToContinue();
                    break;
            }
            return val;
        }

        private string PickOrder()
        {
            Console.WriteLine("Enter the order you wish to view.");
            Console.WriteLine("Or Enter nothing to continue.");
            string val = Console.ReadLine();
            if (val != "")
            {
                try
                {
                    ShowOrder(OrderBL.FindOrder(Int32.Parse(val)));
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Input could not be understood");
                }
                EnterToContinue();
            }
            return val;
        }

        private void ShowOrder(Orders orders)
        {
            StoreFront store = StoreFrontBL._storeFrontBL.FindStore(orders.LocationId);
            Customer customer = CustomerBL.SearchCustomer(orders.CustomerId);
            Console.Clear();
            Console.WriteLine($"Order Id:      {orders.Id}");
            Console.WriteLine($"Store Name:    {store.Name}");
            Console.WriteLine($"Store Address: {store.Address}");
            Console.WriteLine($"Customer Name: {customer.Name}");
            Console.WriteLine("----- Items Purchased -----");
            foreach (LineItems item in orders.LineItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Total Price: ${orders.TotalPrice}");
            Console.WriteLine("---------------------------");
        }
    }
}