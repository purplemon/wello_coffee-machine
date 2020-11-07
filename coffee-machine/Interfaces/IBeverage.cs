using System;
using System.Collections.Generic;
using System.Text;

namespace coffee_machine
{
    interface IBeverage
    {
        public string Name { get; }
        public string Size { get; }
        public decimal BasePrice { get; }

        public decimal TotalPrice { get; }
    }
}
