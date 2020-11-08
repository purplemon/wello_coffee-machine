using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coffee_machine.Models
{
    class BeverageSizeAndPrice : IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }

    }
}
