using CoffeeMachine.Models;
using CoffeeMachine.Utilities;
using System;
using System.Linq;

namespace CoffeeMachine.Controller
{
    class CoffeeMachineController
    {
        public static bool StartCoffeeMachine()
        {

            // Welcome Message
            PrintWelcomeMessage();

            Order order = GetNewOrder();
            

            // Check if order was successful
            if (order != null)
            {
                
                Console.WriteLine("\nThank you for your order. Goodbye!\n");
                return true;
            } else
            {
                Console.WriteLine("\nYour order was not completed.\n");
                return false;
            }

        }

        public static Order GetNewOrder()
        {
            try
            {
                
                // Get menu
                CoffeeMenu coffeeMenu = GetCoffeeMenu();
                
                // Build Order
                Order order = new Order(coffeeMenu);
                order.BuildOrder();

                // Process Orcer
                order.ProcessPayment();

                return order;
            } catch (Exception e)
            {
                Console.Error.Write("An error occured while building the order:" + e);
                return null;
            }
            
        }


        static void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello! Welcome to CSharpBucks(TM)\r");
            Console.WriteLine("---------------------------------\n");

        }

        public static CoffeeMenu GetCoffeeMenu()
        {
            CoffeeMenu coffeeMenu = new CoffeeMenu();

            // Prompt to optionally see menu
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
            if (userResponse == "menu") { coffeeMenu.PrintMenu(); }

            return coffeeMenu;
        }
    }
}
