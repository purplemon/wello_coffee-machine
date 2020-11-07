using coffee_machine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_machine.Models
{
    class Coffee : IBeverage
    {
        private CoffeePriceList _priceList;
        public Coffee(CoffeePriceList priceList)
        {
            this._priceList = priceList;
        }

        public string Name { get; set; } = "coffee";
        public string Size { get; set; }
        public decimal BasePrice
        {
            get
            {
                return _priceList.SizeOptionList.Where(x => x.Size == Size).Select(x => x.Price).FirstOrDefault();
            }
        }

        public int NumberOfSugars { get; set; } = 0; // default to 0 sugars
        public int NumberOfCreams { get; set; } = 0; // default to 0 creams

        public decimal TotalPrice
        {
            get
            {
                decimal creamPrice = NumberOfCreams * _priceList.CreamPrice;
                decimal sugarPrice = NumberOfSugars * _priceList.SugarPrice;
                return BasePrice + creamPrice + sugarPrice;
            }
        }

        public void PrintSummary()
        {
            Console.WriteLine("\nThe total for this " + Name + " will be:\r");
            Console.WriteLine("\tSize: " + Size + "\t\t" + BasePrice.ToString("C") + "\r");
            Console.WriteLine("\t\t" + NumberOfSugars + " sugars\t" + (_priceList.SugarPrice * NumberOfSugars).ToString("C") + "\r");
            Console.WriteLine("\t\t" + NumberOfCreams + " creams\t" + (_priceList.CreamPrice * NumberOfCreams).ToString("C") + "\r");
            Console.WriteLine("\t---------------------------------\r");
            Console.WriteLine("\tTOTAL" + "\t\t\t" + TotalPrice.ToString("C") + "\r");
        }


        public string PromptForSize()
        {
            string prompt = "What size would you like? (";
            foreach (var size in _priceList.SizeOptionList)
            {
                prompt = prompt + size.Size.ToLower() + "/";
            }
            prompt.Trim('/');
            prompt = prompt + ")";

            Utility u = new Utility();
            string userResponse = u.GetUserInput(prompt);
            while (_priceList.SizeOptionList.Where(x => x.Size == userResponse).Count() < 1)
            {
                // prompt again
                userResponse = u.GetUserInput("Invalid size.");
            }
            return userResponse;
        }


        public string PromptForAddIns(string name)
        {
            string prompt = "\n" +
                    "How many " + name + " would you like? You may select up to 3.";
            Utility u = new Utility();
            string userResponse = u.GetUserInput(prompt);
            while (!int.TryParse(userResponse, out int num) || Convert.ToInt32(userResponse) < 0 || Convert.ToInt32(userResponse) > 3)
            {
                // prompt again
                userResponse = u.GetUserInput("Please specify an integer from 0 to 3:");
            }
            return userResponse;
        }
    }
}

