using CoffeeMachine.Interface;
using CoffeeMachine.Models;
using CoffeeMachine.Utilities;
using System;
using System.Collections;
using System.Linq;

namespace CoffeeMachine.Controller
{
    public class CoffeeMachineController
    {

        private CoffeeMenu _priceList;
        private IPrompt _prompt;
        private IOrder _order;
        public CoffeeMachineController()
        {
            PrintWelcomeMessage();

            this._priceList = new CoffeeMenu();
            this._prompt = new Prompt();
            this._order = new Order(_priceList, _prompt);
        }

        public IOrder GetNewOrder()
        {
            try
            {

                // Display Menu
                string userResponse = PromptForCoffeeMenu();
                if (userResponse == "menu")
                {
                    _priceList.PrintMenu();
                }

                // Build Order
                _order.Build();

                // Process Order
                _order.ProcessPayment();

                return _order;
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

        public virtual string PromptForCoffeeMenu()
        {
            // Prompt to optionally see menu
            _prompt.Message = "What can I get for you?\n" +
                "\t'menu' - View menu and prices\n" +
                "\t'order' - Create order\n";
            string userResponse = _prompt.GetUserInput();
            string[] expectedResponse = { "order", "menu" };
            while (!((IList)expectedResponse).Contains(userResponse))
            {
                // prompt again
                _prompt.Message = "Invalid option";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }
    }
}
