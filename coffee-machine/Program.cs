using coffee_machine.Models;
using System;
using System.Linq;

namespace coffee_machine
{
    class Program
    {
        static void Main(string[] args)
        {

            var newSale = new CoffeeMachineController();

            //End
            Console.WriteLine("\nFinished. Press any key to exit");
            Console.ReadKey();
        }
    }
}
