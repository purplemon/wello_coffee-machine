using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace coffee_machine.Utilities
{
    class Prompt
    {
        public  string Message { get; set; }

        public string GetUserInput()
        {
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.Green;
            string response = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            return response;
        }

        public static string CleanCurrencyInput(string dirtyString)
        {
            // Replace $ characters with empty strings.
            try
            {
                return Regex.Replace(dirtyString, @"^[\$]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }

}
