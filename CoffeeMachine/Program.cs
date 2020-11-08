using CoffeeMachine.Controller;
using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start Application
            CoffeeMachineController.StartCoffeeMachine();

            //End
            Console.WriteLine("\nThe coffe machine will now shut down. Press any key to exit");
            Console.ReadKey();
        }
    }
}
