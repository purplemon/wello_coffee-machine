﻿using coffee_machine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace coffee_machine.Models
{
    class Order : IOrder
    {

        private CoffeePriceList _priceList;
        public Order(CoffeePriceList priceList)
        {
            this._priceList = priceList;
        }


        public IList<IBeverage> BeverageList { get; set; } = new List<IBeverage> { };
        public decimal TotalPrice {
            get {
                return BeverageList.Sum(x => x.TotalPrice);
            } }
        public string PaymentType { get; set; } = "Cash";
        public decimal PaymentReceived { get; set; } = 0;
        public decimal ChangeDue { get { return PaymentReceived - TotalPrice; } }

        public void BuildOrder()
        {

            string userResponse;
            do
            {
                //Build coffee
                Coffee coffee = new Coffee(_priceList);
                coffee.BuildCoffee();

                // Add to order
                BeverageList.Add(coffee);


                // Prompt to add another coffee
                Prompt prompt = new Prompt();
                prompt.Message = "\n" +
                    "Would you like to add another coffee to your order? Please specify yes or no:"; 
                userResponse = prompt.GetUserInput();

                string[] expectedResponse = { "yes", "no" };
                while (!expectedResponse.Contains(userResponse))
                {
                    // prompt again
                    prompt.Message = "Please specify yes or no:";
                    userResponse = prompt.GetUserInput();
                }
                if (userResponse == "yes")
                {
                    Console.WriteLine("You have selected to add another coffee.");
                }

            } while (userResponse == "yes");
            
            // Print order totals
            PrintOrderSummary();

            //Console.WriteLine("Order Created!");
        }

        public void PrintOrderSummary()
        {

            Console.WriteLine("\n===========================================\n");
            Console.WriteLine("\t\tORDER SUMMARY");
            Console.WriteLine("\n===========================================\n");

            Console.WriteLine("Total coffees ordered:\t" + BeverageList.Count() + "\n\n");
            for ( int orderItem = 0; orderItem < BeverageList.Count(); orderItem++)
            {
                Coffee coffee = new Coffee(_priceList);
                coffee = (Coffee)BeverageList[orderItem];
                Console.WriteLine("\n\n-------------------------------------------");
                Console.WriteLine("Order Item #" + (orderItem+1));
                Console.WriteLine("-------------------------------------------\n");
                coffee.PrintSummary();
            }

            Console.WriteLine("\n===========================================\n");
            Console.WriteLine("ORDER TOTAL:\t" + TotalPrice.ToString("C") + "\n\n");
        }

        public void ProcessPayment()
        {

            PaymentReceived = PromptForPayment();


            // Return change to the customer.
            if (PaymentReceived != TotalPrice) { DispenseChange(); }

        }

        public void DispenseChange()
        {
            Console.WriteLine("Here is your change:\t" + ChangeDue.ToString("C"));
        }

        public decimal PromptForPayment()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "\n" +
                    "Please pay for your order using " + PaymentType.ToLower()+ ". Enter the amount to pay:";

            //Get input and trim any $ symbol, the user might have specified.
            string userResponse = Prompt.CleanCurrencyInput(prompt.GetUserInput());


            while (!decimal.TryParse(userResponse, out decimal num) || Convert.ToDecimal(userResponse) < TotalPrice) // while not a decimal value that is at least the amount requested
            {
                // Validate Payment (did they give enough money?)
                if (decimal.TryParse(userResponse, out num) && (Convert.ToDecimal(userResponse) < TotalPrice))
                {
                    prompt.Message = "Inadequate amount received. You are " + (TotalPrice - Convert.ToDecimal(userResponse)).ToString("C") +  " short. Please pay the full amount: " + TotalPrice.ToString("C");
                } else
                {
                    prompt.Message = "That is not a valid numeric response. Please enter a number:";
                }
                
                //Get input and trim any $ symbol, the user might have specified.
                userResponse = Prompt.CleanCurrencyInput(prompt.GetUserInput());
            }
            return Convert.ToDecimal(userResponse);
        }
    }
}