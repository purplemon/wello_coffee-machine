using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace coffee_machine
{
    interface IBeveragePriceList
    {
        public IList<IBeverageSizeAndPrice> SizeOptionList { get; }
    }
}
