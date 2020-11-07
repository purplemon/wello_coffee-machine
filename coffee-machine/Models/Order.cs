using coffee_machine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                return PaymentReceived;
            } }
        public string PaymentType { get; set; } = "Cash";
        public decimal PaymentReceived { get; set; } = 0;
        public decimal ChangeDue { get { return TotalPrice - PaymentReceived; } }

        public void BuildOrder()
        {

            string userResponse = "y";
            do
            {
                //Build coffee
                Coffee coffee = new Coffee(_priceList);


                // Select Size
                coffee.Size = coffee.PromptForSize();

                // Prompt for sugar
                coffee.NumberOfSugars = Convert.ToInt32(coffee.PromptForAddIns("sugars"));

                // Prompt for cream
                coffee.NumberOfCreams = Convert.ToInt32(coffee.PromptForAddIns("creams"));

                // Add to order
                BeverageList.Add(coffee);

                //Print Order Summary
                coffee.PrintSummary();



                // Add another coffee
                string prompt = "\n" +
                    "Would you like to add another coffee to your order? \n" +
                    "---------------------------------\n";

                Utility u = new Utility();
                userResponse = u.GetUserInput(prompt);
                string[] expectedResponse = { "y", "n" };
                while (!expectedResponse.Contains(userResponse))
                {
                    // prompt again
                    prompt = "Please specify Y(es) or N(no):";
                    userResponse = u.GetUserInput(prompt);
                }
                Console.WriteLine("The user response was " + userResponse);

            } while (userResponse == "y");

            Console.WriteLine("Order Created!");
        }

    }
}
