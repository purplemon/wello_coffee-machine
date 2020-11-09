using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Interface
{
    public interface IPrompt
    {
        public string Message { get; set; }

        public string GetUserInput();

    }
}
