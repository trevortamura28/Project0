using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class User
    {
      public int ZipCode;
      public bool HasOrdered;
      public Name UserName;
      public List<Order> CustomerOrderHistory;

      public User()
      {
        CustomerOrderHistory = new List<Order>();
        HasOrdered = false;
      }

      public void RegisterUser()
      {
        UserName = new Name();
        string holdNumber;
        bool success = false;
        System.Console.WriteLine("What is your first name? ");
        UserName.FirstName = System.Console.ReadLine();
        System.Console.WriteLine("What is your last name? ");
        UserName.LastName = System.Console.ReadLine();
        while (success==false)
        {
        System.Console.WriteLine("In What zipcode are you located? ");
        holdNumber = System.Console.ReadLine();
        success = int.TryParse(holdNumber, out ZipCode);
        }
        System.Console.WriteLine("Thank you for registering. ");
        UserName.SetLongName();
      }

    

    }

    
}
