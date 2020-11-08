using System;
using System.Collections.Generic;
using CoffeeMachine.Inerface;

namespace CoffeeMachine.Models
{
    class CoffeeMenu : IBeverageMenu
    {
        public IList<IBeverageSizeAndPrice> SizeOptionList { get; }

        public CoffeeMenu()
        {

            SizeOptionList = new List<IBeverageSizeAndPrice>
            {
                new BeverageSizeAndPrice { Size = "small", Price = 2.95m },
                new BeverageSizeAndPrice { Size = "medium", Price = 3.25m },
                new BeverageSizeAndPrice { Size = "large", Price = 3.95m }
            };
        }

        // Optional Add-Ins
        public decimal SugarPrice { get; } = 0.25m;

        public decimal CreamPrice { get; } = 0.50m;

        public int MaxNumberOfCreams { get; set; } = 3;
        public int MaxNumberOfSugars { get; set; } = 3;

        public void PrintMenu()
        {
            Console.WriteLine("\nWe are currently serving: IMAGINARY COFFEE\r");
            Console.WriteLine("\nThe options for sizes are:");
            foreach (var size in SizeOptionList)
            {
                Console.WriteLine("\t" + size.Size.ToLower() + "\t\t" + size.Price.ToString("C"));
            }
            Console.WriteLine("\nYou may order up to " + MaxNumberOfSugars  + " sugar and " + MaxNumberOfCreams + " cream in your coffee for an additional fee as follows:");
            Console.WriteLine("\tsugar \t\t " + SugarPrice.ToString("C") + " each");

            Console.WriteLine("\tcream \t\t " + CreamPrice.ToString("C") + " each");
            Console.WriteLine("");
        }

    }
}