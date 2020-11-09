using NUnit.Framework;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine.Models;
using CoffeeMachine.Controller;
using CoffeeMachine.Utilities;
using CoffeeMachine.Interface;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class CoffeeMachineControllerTests
    {
        [Test]
        [TestCase("order", "order")]
        [TestCase("Menu", "menu")]
        public void PromptForCoffeeMenu_UserSelectsValidOption_ReturnsUserInput(string fakeInput, string expectedResponse)
        {

            TestCoffeeMachineController testController = new TestCoffeeMachineController(fakeInput);

            var result = testController.PromptForCoffeeMenu();

            Assert.That(result == expectedResponse);

        }

        [Test]
        public void PromptForCoffeeMenu_UserInputsInvalidString_ShouldBeInfiniteLoop()
        {
            string fakeInput = "garbage";

            TestCoffeeMachineController testController = new TestCoffeeMachineController(fakeInput);

            Task t = Task.Run(() => testController.PromptForCoffeeMenu());

            Thread.Sleep(5000);
        }

    }

    // Class needed to change implementation for test purposes.
    public class TestPrompt : Prompt
    {
        private string _fakeResponse;
        public TestPrompt(string response)
        {
            this._fakeResponse = response.ToLower();
        }

        public override string GetUserInput()
        {
            return _fakeResponse;
        }
    }


    public class TestCoffeeMachineController : CoffeeMachineController
    {
        private CoffeeMenu _priceList;
        private TestPrompt _prompt;
        private IOrder _order;
        public TestCoffeeMachineController(string fakeResponse)
        {

            this._priceList = new CoffeeMenu();
            this._prompt = new TestPrompt(fakeResponse);
            this._order = new Order(_priceList, _prompt);
        }


        public override string PromptForCoffeeMenu()
        {
            // Prompt to optionally see menu
            _prompt.Message = "What can I get for you?\n" +
                "\t'menu' - View menu and prices\n" +
                "\t'order' - Create order\n";
            string userResponse = _prompt.GetUserInput();
            string[] expectedResponse = { "order", "menu" };
            while (!((IList)expectedResponse).Contains(userResponse))
            {
                // prompt again
                _prompt.Message = "Invalid option";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }
    }

}
