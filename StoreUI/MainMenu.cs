using System;

namespace StoreUI
{
    class MainMenu : AMenu, IMenu
    {
        public MainMenu()
        {
            
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(
@"    ___   ________  _________
   /   | / ____/  |/  / ____/
  / /| |/ /   / /|_/ / __/   
 / ___ / /___/ /  / / /___   
/_/  |_\____/_/  /_/_____/   ");
            Console.WriteLine();
            Console.WriteLine("Welcome! Please make a selection");
            Console.WriteLine();
            Console.WriteLine("[3] Orders");
            Console.WriteLine("[2] Store Inventory");
            Console.WriteLine("[1] Customers");
            Console.WriteLine("[0] Exit");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions val = MenuOptions.MainMenu;
            switch (info)
            {
                case "0":
                val = MenuOptions.Exit;
                    break;
                case "1":
                    val = MenuOptions.CustomerOptions;
                    break;
                case "2":
                    val = MenuOptions.InventoryOptions;
                    break;
                case "3":
                    val = MenuOptions.OrderOptions;
                    break;
                default:
                    Console.WriteLine("Unable to determine input.");
                    val = MenuOptions.MainMenu;
                    EnterToContinue();
                    break;
            }
            return val;
        }
    }
}