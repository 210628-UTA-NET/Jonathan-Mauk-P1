using System;
using StoreAppBL;

namespace StoreUI
{
    class AddCustomerMenu : AMenu, IMenu
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(@"
                   _   __                        
                  / | / /__ _      __            
                 /  |/ / _ \ | /| / /            
                / /|  /  __/ |/ |/ /             
   ______      /_/ |_/\___/|__/|__/              
  / ____/_  _______/ /_____  ____ ___  ___  _____
 / /   / / / / ___/ __/ __ \/ __ `__ \/ _ \/ ___/
/ /___/ /_/ (__  ) /_/ /_/ / / / / / /  __/ /    
\____/\__,_/____/\__/\____/_/ /_/ /_/\___/_/     
                                                 ");
            Console.WriteLine("Welcome! Please enter the customer's information");
            Console.WriteLine("[1] Add a customer");
            Console.WriteLine("[0] Return to Customer Options");
        }

        public MenuOptions YourChoice()
        {
            string info = Console.ReadLine();
            MenuOptions menu = MenuOptions.AddCustomerMenu;
            switch (info)
            {
                case "0":
                    menu = MenuOptions.CustomerOptions;
                    break;
                case "1":
                    AddCustomer();
                    break;
                default:
                    Console.WriteLine("Your input could not be understood.");
                    EnterToContinue();
                    break;
            }
            
            return menu;
        }

        private void AddCustomer() 
        {
            Console.WriteLine("Enter the new customer's name.");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new customer's address.");
            string address = Console.ReadLine(); 
            Console.WriteLine("Enter the new customer's email.");
            string email = Console.ReadLine(); 
            Console.WriteLine("Enter the new customer's phone number.");
            string phoneNumber = Console.ReadLine(); 
            
            if (CustomerBL.AddCustomer(name, address, email, phoneNumber))
            {
                System.Console.WriteLine("The Customer was Successfully added!");
            }
            else
            {
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Console.WriteLine("ERROR: The Customer could not be added.");
                System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            EnterToContinue();
        }
    }
}