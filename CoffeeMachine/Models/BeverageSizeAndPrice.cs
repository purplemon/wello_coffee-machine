using CoffeeMachine.Interface;

namespace CoffeeMachine.Models
{
    public class BeverageSizeAndPrice : IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }

    }
}
