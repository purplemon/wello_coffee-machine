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
            Console.WriteLine("\n   The details for this " + Name + " are:\r\n");
            Console.WriteLine("\tSIZE: " + Size + "\t\t" + BasePrice.ToString("C") + "\r");
            Console.WriteLine("\t\t" + NumberOfSugars + " sugars\t" + (_priceList.SugarPrice * NumberOfSugars).ToString("C") + "\r");
            Console.WriteLine("\t\t" + NumberOfCreams + " creams\t" + (_priceList.CreamPrice * NumberOfCreams).ToString("C") + "\r");
            Console.WriteLine("\t---------------------------------\r");
            Console.WriteLine("\tTOTAL" + "\t\t\t" + TotalPrice.ToString("C") + "\r");
        }


        public string PromptForSize()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "What size would you like? (";
            foreach (var size in _priceList.SizeOptionList)
            {
                prompt.Message = prompt.Message + size.Size.ToLower() + "/";
            }
            prompt.Message.Trim('/');
            prompt.Message = prompt.Message + ")";

            
            string userResponse = prompt.GetUserInput();
            while (_priceList.SizeOptionList.Where(x => x.Size == userResponse).Count() < 1) // while not a valid size option
            {
                // prompt again
                prompt.Message = "Invalid size.";
                userResponse = prompt.GetUserInput();
            }
            return userResponse;
        }


        public string PromptForAddIns(string name, int maxNumber)
        {
            Prompt prompt = new Prompt();
            prompt.Message = "\n" +
                    "How many " + name + " would you like? You may select 0 to " + maxNumber + ".";
            
            string userResponse = prompt.GetUserInput();
            while (!int.TryParse(userResponse, out int num) || Convert.ToInt32(userResponse) < 0 || Convert.ToInt32(userResponse) > maxNumber) // while not an integer value between 0 and maxNumber
            {
                // prompt again
                prompt.Message = "Please specify an integer from 0 to " + maxNumber + ":";
                userResponse = prompt.GetUserInput();
            }
            return userResponse;
        }

        public void BuildCoffee()
        {
            // Select Size
            Size = PromptForSize();

            // Prompt for sugar
            NumberOfSugars = Convert.ToInt32(PromptForAddIns("sugars", _priceList.MaxNumberOfSugars));

            // Prompt for cream
            NumberOfCreams = Convert.ToInt32(PromptForAddIns("creams", _priceList.MaxNumberOfCreams));

            //Print Coffee Summary
            PrintSummary();
        }
    }
}

