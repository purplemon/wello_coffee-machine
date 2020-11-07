using System;
using System.Collections.Generic;

namespace coffee_machine.Models
{
    class CoffeePriceList : IBeveragePriceList
    {
        public IList<IBeverageSizeAndPrice> SizeOptionList { get; }

        public CoffeePriceList()
        {

            SizeOptionList = new List<IBeverageSizeAndPrice>
            {
                new BeverageSizeAndPrice { Size = "small", Price = 1.95m },
                new BeverageSizeAndPrice { Size = "medium", Price = 2.95m },
                new BeverageSizeAndPrice { Size = "large", Price = 3.95m }
            };
        }

        // Optional Add-Ins
        public decimal SugarPrice { get; } = 0.25m;

        public decimal CreamPrice { get; } = 0.50m;

        public void PrintMenu()
        {
            Console.WriteLine("\nWe are currently serving: IMAGINARY COFFEE\r");
            Console.WriteLine("\nThe options for sizes are:");
            foreach (var size in SizeOptionList)
            {
                Console.WriteLine("\t" + size.Size.ToLower() + "\t\t" + size.Price.ToString("C"));
            }
            Console.WriteLine("\nYou may order up to 3 sugar and 3 cream in your coffee for an additional fee as follows:");
            Console.WriteLine("\tsugar \t\t " + SugarPrice.ToString("C") + " each");

            Console.WriteLine("\tcream \t\t " + CreamPrice.ToString("C") + " each");
            Console.WriteLine("");
        }

    }
}