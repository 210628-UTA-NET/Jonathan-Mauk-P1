using System;

namespace StoreUI
{
    public enum MenuOptions
    {
        MainMenu,
        CustomerOptions,
        AddCustomerMenu,
        ListCustomerMenu,
        SearchCustomer,
        InventoryOptions,
        ViewStoreInv,
        ReplenishInventory,
        OrderOptions,
        PlaceOrder,
        ViewOrderHistory,
        Exit
    }
    public interface IMenu
    {
        /// <summary>
        /// Shows the menu
        /// </summary>
        void Menu();

        /// <summary>
        /// Reads user input to respond to the user's choice
        /// </summary>
        /// <returns>A MenuOptions enum based off of the users input</returns>
        MenuOptions YourChoice();
    }

    abstract class AMenu
    {
        protected void EnterToContinue()
        {
            Console.WriteLine("Press Enter to continue . . .");
            Console.ReadLine();
        }
    }
}
