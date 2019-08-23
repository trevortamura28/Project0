using System;
using System.Collections;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : CustomerInput
    {
      public Topping(string n)
      {
        Name = n;
      }

    }
}