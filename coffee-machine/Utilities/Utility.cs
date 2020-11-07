using System;
using System.Collections.Generic;
using System.Text;

namespace coffee_machine.Utilities
{
    class Utility
    {
        public string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ForegroundColor = ConsoleColor.Green;
            string response = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            return response;
        }
    }
}
