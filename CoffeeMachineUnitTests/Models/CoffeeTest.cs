using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoffeeMachine.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class CoffeeTests
    {
        [Test]
        [TestCase("small", "small")]
        [TestCase("medium", "medium")]
        [TestCase("Large", "large")]
        public void PromptForSize_UserSelectsValidOption_ReturnsUserInput(string fakeInput, string expectedResponse)
        {
            TestCoffee testCoffee = new TestCoffee(new CoffeeMenu(), fakeInput);

            var result = testCoffee.PromptForSize();

            Assert.That(result == expectedResponse);

        }

        [Test]
        public void PromptForSize_UserSelectsInvalidOption_ShouldBeInfiniteLoop()
        {
            string fakeInput = "garbage";

            TestCoffee testCoffee = new TestCoffee(new CoffeeMenu(), fakeInput);

            Task t = Task.Run(() => testCoffee.PromptForSize());

            Thread.Sleep(5000);

        }

        [Test]
        public void PromptForAddIn_UserSelectsCreamAndValidNumberOption_ReturnsUserInput()
        {
            string fakeInput = "0";

            TestCoffee testCoffee = new TestCoffee(new CoffeeMenu(), fakeInput);

            var result = testCoffee.PromptForSize();

            Assert.That(result == 0.ToString());

        }

        [Test]
        //[TestCase("-1")]
        //[TestCase("garbage")]
        //[TestCase("4")]
        public void PromptForAddIn_UserSelectsCreamAndInvalidNumberOption_ShouldBeInfiniteLoop()
        {
            string fakeInput = "-1";

            TestCoffee testCoffee = new TestCoffee(new CoffeeMenu(), fakeInput);

            Task t = Task.Run(() => testCoffee.PromptForSize());

            Thread.Sleep(5000);

        }

        public void BuildCoffee()
        {

        }

    }

    public class TestCoffee : Coffee
    {
        private CoffeeMenu _priceList;
        private TestPrompt _prompt;
        public TestCoffee(CoffeeMenu priceList, string fakeResponse)
        {
            this._priceList = priceList;
            this._prompt = new TestPrompt(fakeResponse);
        }

        public override string PromptForSize()
        {
            _prompt.Message = "What size would you like? (";
            foreach (var size in _priceList.SizeOptionList)
            {
                _prompt.Message = _prompt.Message + size.Size.ToLower() + "/";
            }
            _prompt.Message.Trim('/');
            _prompt.Message = _prompt.Message + ")";


            string userResponse = _prompt.GetUserInput();
            while (_priceList.SizeOptionList.Where(x => x.Size == userResponse).Count() < 1) // while not a valid size option
            {
                // prompt again
                _prompt.Message = "Invalid size.";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }

        public override string PromptForAddIn(string addInName, int maxNumber)
        {
            _prompt.Message = "\n" +
                    "How many " + addInName + " would you like? You may select 0 to " + maxNumber + ".";

            string userResponse = _prompt.GetUserInput();
            while (!int.TryParse(userResponse, out int num) || Convert.ToInt32(userResponse) < 0 || Convert.ToInt32(userResponse) > maxNumber) // while not an integer value between 0 and maxNumber
            {
                // prompt again
                _prompt.Message = "Please specify an integer from 0 to " + maxNumber + ":";
                userResponse = _prompt.GetUserInput();
            }
            return userResponse;
        }

    }
}
