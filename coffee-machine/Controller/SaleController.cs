using coffee_machine.Models;
using coffee_machine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_machine
{
    class SaleController
    {
        public SaleController()
        {

            // Welcome Message
            PrintWelcomeMessage();


            // Create Menu Object
            CoffeePriceList coffeeMenu = new CoffeePriceList();
            
            // Prompt to see menu or proceed with ordering
            string userResponse = PromptForMenu();
            if (userResponse == "menu") { coffeeMenu.PrintMenu(); }


            // Build Order
            Order order = new Order(coffeeMenu);
            order.BuildOrder(); 
        }


        void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello! Welcome to CSharpBucks(TM)\r");
            Console.WriteLine("---------------------------------\n");

        }

        string PromptForMenu()
        {
            string prompt = "What can I get for you?\n" +
                "\t'menu' - View menu and prices\n" +
                "\t'order' - Create order\n";
            
            Utility u = new Utility();

            string userResponse = u.GetUserInput(prompt);
            string[] expectedResponse = { "order", "menu" };
            while (!expectedResponse.Contains(userResponse))
            {
                // prompt again
                userResponse = u.GetUserInput(prompt);
            }
            return userResponse;
        }
    }
}
