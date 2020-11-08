using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Inerface
{
    interface IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }
    }
}
