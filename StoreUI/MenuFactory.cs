using System;

namespace StoreUI
{
    public class MenuFactory : IMenuFactory
    {
        public IMenu GetMenu(MenuOptions option)
        {
            IMenu menu = null;
            switch (option)
            {
                case MenuOptions.Exit:
                    menu = null;
                    break;
                case MenuOptions.CustomerOptions:
                    menu = new CustomerOptionsMenu();
                    break;
                case MenuOptions.ListCustomerMenu:
                    menu = new ListCustomerMenu();
                    break;
                case MenuOptions.AddCustomerMenu:
                    menu = new AddCustomerMenu();
                    break;
                case MenuOptions.MainMenu:
                    menu = new MainMenu();
                    break;
                case MenuOptions.SearchCustomer:
                    menu = new CustomerSearchMenu();
                    break;
                case MenuOptions.InventoryOptions:
                    menu = new InventoryOptionsMenu();
                    break;
                case MenuOptions.ViewStoreInv:
                    menu = new ViewStoreInvMenu();
                    break;
                case MenuOptions.ReplenishInventory:
                    menu = new ReplenishInventoryMenu();
                    break;
                case MenuOptions.OrderOptions:
                    menu = new OrderOptionsMenu();
                    break;
                case MenuOptions.ViewOrderHistory:
                    menu = new ViewOrderMenu();
                    break;
                case MenuOptions.PlaceOrder:
                    menu = new PlaceOrderMenu();
                    break;
                default:
                    menu = new MainMenu();
                    Console.WriteLine("Could not understand input.");
                    break;
            }
            return menu;
        }
    }
}