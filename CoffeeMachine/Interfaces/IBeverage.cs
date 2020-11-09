using CoffeeMachine.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Interface
{
    public interface IBeverage
    {

        public string Name { get; }
        public string Size { get; }
        public decimal BasePrice { get; }
        public decimal TotalPrice { get; }

        void PrintSummary();
        string PromptForSize();
        string PromptForAddIn(string name, int maxNumber);
        void Build();

    }
}
