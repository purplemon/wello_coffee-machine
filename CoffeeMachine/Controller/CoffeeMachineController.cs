using coffee_machine.Models;
using coffee_machine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_machine
{
    class CoffeeMachineController
    {
        public static void StartCoffeeMachine()
        {
            try
            {
                // Welcome Message
                PrintWelcomeMessage();


                // Prepare Menu
                CoffeeMenu coffeeMenu = new CoffeeMenu();

                // Prompt to see menu or proceed with ordering
                string userResponse = PromptForMenu();
                if (userResponse == "menu") { coffeeMenu.PrintMenu(); }


                // Build Order
                Order order = new Order(coffeeMenu);
                order.BuildOrder();

                // Process Orcer
                order.ProcessPayment();

                //End
                Console.WriteLine("\nThank you for your order. Goodbye!\n");
            }
            catch (Exception e) {
                Console.Error.Write(e);
            }

        }


        static void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello! Welcome to CSharpBucks(TM)\r");
            Console.WriteLine("---------------------------------\n");

        }

        static string PromptForMenu()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "What can I get for you?\n" +
                "\t'menu' - View menu and prices\n" +
                "\t'order' - Create order\n";
            string userResponse = prompt.GetUserInput();
            string[] expectedResponse = { "order", "menu" };
            while (!expectedResponse.Contains(userResponse))
            {
                // prompt again
                prompt.Message = "Invalid option";
                userResponse = prompt.GetUserInput();
            }
            return userResponse;
        }
    }
}
