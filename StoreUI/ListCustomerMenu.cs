using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreModels;

namespace StoreUI 
{
    class ListCustomerMenu : AMenu, IMenu
    {
        public ListCustomerMenu()
        {
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(@"
                   ___   ________  _________          
                  /   | / ____/  |/  / ____/          
                 / /| |/ /   / /|_/ / __/             
                / ___ / /___/ /  / / /___             
   ______      /_/  |_\____/_/  /_/_____/             
  / ____/_  _______/ /_____  ____ ___  ___  __________
 / /   / / / / ___/ __/ __ \/ __ `__ \/ _ \/ ___/ ___/
/ /___/ /_/ (__  ) /_/ /_/ / / / / / /  __/ /  (__  ) 
\____/\__,_/____/\__/\____/_/ /_/ /_/\___/_/  /____/  
                                                      ");
            Console.WriteLine("======================================================");
            foreach (Customer item in CustomerBL.ListCustomers())
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("------------------------------------------------");
            }
        }

        public MenuOptions YourChoice()
        {
            Console.Write("To return to Customer Options ");
            EnterToContinue();
            return MenuOptions.CustomerOptions;
        }
    }
}