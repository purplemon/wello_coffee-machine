using CoffeeMachine.Inerface;

namespace CoffeeMachine.Models
{
    class BeverageSizeAndPrice : IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }

    }
}
