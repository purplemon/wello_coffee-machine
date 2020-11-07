using coffee_machine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace coffee_machine
{
    interface IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }
    }
}
