using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CoffeeMachine.Inerface
{
    interface IBeverageMenu
    {
        public IList<IBeverageSizeAndPrice> SizeOptionList { get; }
    }
}
