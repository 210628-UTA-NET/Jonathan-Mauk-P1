using System;

namespace StoreUI
{
    class OrderOptionsMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(@"
       ___   ________  _________  
      /   | / ____/  |/  / ____/  
     / /| |/ /   / /|_/ / __/     
    / ___ / /___/ /  / / /___     
   /_/_ |_\____/_/__/_/_____/     
  / __ \_________/ /__  __________
 / / / / ___/ __  / _ \/ ___/ ___/
/ /_/ / /  / /_/ /  __/ /  (__  ) 
\____/_/   \__,_/\___/_/  /____/  
                                  ");
            Console.WriteLine("[2] View order history");
            Console.WriteLine("[1] Place an order");
            Console.WriteLine("[0] Return to Main Menu");
        }

        public MenuOptions YourChoice()
        {
            string input = Console.ReadLine();
            MenuOptions choice = MenuOptions.InventoryOptions;
            switch (input)
            {
                case "0":
                    choice = MenuOptions.MainMenu;
                    break;
                case "1":
                    choice = MenuOptions.PlaceOrder;
                    break;
                case "2":
                    choice = MenuOptions.ViewOrderHistory;
                    break;
                default:
                    Console.WriteLine("Input could not be understood.");
                    EnterToContinue();
                    break;
            }
            return choice;
        }
    }
}