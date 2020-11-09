using CoffeeMachine.Controller;
using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start Application
            CoffeeMachineController controller = new CoffeeMachineController();
            
            var order = controller.GetNewOrder();


            // Check if order was successful
            if (order != null)
            {

                Console.WriteLine("\nThank you for your order. Goodbye!\n");
            }
            else
            {
                Console.WriteLine("\nYour order was not completed.\n");
            }

            //End
            Console.WriteLine("\nThe coffe machine will now shut down. Press any key to exit");
            Console.ReadKey();
        }
    }
}
