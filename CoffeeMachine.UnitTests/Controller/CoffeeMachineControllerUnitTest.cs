using NUnit.Framework;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine.Models;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class CoffeeMachineControllerTests
    {
        [Test]
        public void StartCoffeeMachine_WhenCalled()
        {

        }

        [Test]
        public void GetCoffeeMenu_WhenCalled_ReturnsCoffeeMenu()
        {
            Assert.IsInstanceOf(typeof(CoffeeMenu), GetCoffeeMenu());
        }

        public void GetNewOrder_WhenCalled_ReturnsOrder()
        {

        }


        public void PrintWelcomeMessage_WhenCalled_ReturnsVoid()
        {

        }

    }

}
