using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          Location Loc = new Location();
          UserInterface UII = new UserInterface();
          UII.L = UII.GetLocation();
          UII.UIMain();
          System.Console.WriteLine("Thank you for visiting Trevor's PizzaBox. Have a nice day. ");
        }

    }
}
