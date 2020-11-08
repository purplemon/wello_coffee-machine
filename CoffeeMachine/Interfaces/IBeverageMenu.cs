using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace coffee_machine
{
    interface IBeverageMenu
    {
        public IList<IBeverageSizeAndPrice> SizeOptionList { get; }
    }
}
