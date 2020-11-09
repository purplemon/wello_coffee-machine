﻿using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Interface
{
    public interface IBeverageSizeAndPrice
    {
        public decimal Price { get; set; }
        public string Size { get; set; }
    }
}
