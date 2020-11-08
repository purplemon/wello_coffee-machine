﻿using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Inerface
{
    interface IOrder
    {
        public IList<IBeverage> BeverageList { get; set; }
        public decimal TotalPrice { get; }
        public string PaymentType { get; set; }
        public decimal PaymentReceived { get; set; }
        public decimal ChangeDue { get { return TotalPrice * PaymentReceived; } }

        void PrintOrderSummary();
        void BuildOrder();
        void ProcessPayment();

    }
}
