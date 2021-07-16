using System;
using StoreModels;
using StoreUI;
using System.Collections.Generic;

namespace P0
{
    class StoreApp
    {
        static void Main(string[] args)
        {
            IMenu menu = new MainMenu();
            MenuOptions choice = MenuOptions.MainMenu;
            MenuFactory factory = new MenuFactory();
            bool stay = true;
            while (stay) {
                Console.Clear();
                menu.Menu();
                choice = menu.YourChoice();
                menu = factory.GetMenu(choice);
                if (menu == null) {
                    stay = false;
                }
            } 
        }
    }
}
