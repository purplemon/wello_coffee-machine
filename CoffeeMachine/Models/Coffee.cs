using CoffeeMachine.Interface;
using CoffeeMachine.Utilities;
using System;
using System.Linq;

namespace CoffeeMachine.Models
{
    public class Coffee : IBeverage
    {
        private CoffeeMenu _priceList;
        private IPrompt _prompt;
        public Coffee(CoffeeMenu priceList, IPrompt prompt)
        {
            this._priceList = priceList;
            this._prompt = prompt;
        }
        public Coffee()
        {
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


        public virtual string PromptForSize()
        {
            _prompt.Message = "What size would you like? (";
            foreach (var size in _priceList.SizeOptionList)
            {
                _prompt.Message = _prompt.Message + size.Size.ToLower() + "/";
            }
            _prompt.Message.Trim('/');
            _prompt.Message = _prompt.Message + ")";

            
            string userResponse = _prompt.GetUserInput();
            while (_priceList.SizeOptionList.Where(x => x.Size == userResponse).Count() < 1) // while not a valid size option
            {
                // prompt again
                _prompt.Message = "Invalid size.";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }


        public virtual string PromptForAddIn(string addInName, int maxNumber)
        {
            _prompt.Message = "\n" +
                    "How many " + addInName + " would you like? You may select 0 to " + maxNumber + ".";
            
            string userResponse = _prompt.GetUserInput();
            while (!int.TryParse(userResponse, out int num) || Convert.ToInt32(userResponse) < 0 || Convert.ToInt32(userResponse) > maxNumber) // while not an integer value between 0 and maxNumber
            {
                // prompt again
                _prompt.Message = "Please specify an integer from 0 to " + maxNumber + ":";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }

        public void Build()
        {
            // Select Size
            Size = PromptForSize();

            // Prompt for sugar
            NumberOfSugars = Convert.ToInt32(PromptForAddIn("sugars", _priceList.MaxNumberOfSugars));

            // Prompt for cream
            NumberOfCreams = Convert.ToInt32(PromptForAddIn("creams", _priceList.MaxNumberOfCreams));

            //Print Coffee Summary
            PrintSummary();
        }
    }
}

