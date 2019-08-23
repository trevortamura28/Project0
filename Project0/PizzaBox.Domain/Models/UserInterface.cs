using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class UserInterface
  {
    public User U;
    public Location L;
    public List<Location> ListOfLocations;
    bool End;
    public void UIMain()
    {
      SignIn();
      while (End == false)
      {
        if (U.HasOrdered == false)
        {
          PreOrderMenu();
        }
        else if (U.HasOrdered == true)
        {
          PostOrderMenu();
        }
        else
        {
          System.Console.WriteLine("We shouldnt be here.");
        }
      }
      return;
    }
    public UserInterface(Location l)
    {
      L = l;
      ListOfLocations = new List<Location>{l};
      End = false;
    }

    public void SignIn()
    {
      string input;
      System.Console.WriteLine("Have you been here before? ");
      input = System.Console.ReadLine();
      if (input == "yes")
      {
        U = FindUser();
      }
      else if (input == "no")
      {
        U = new User();
        U.RegisterUser();
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please answer yes or no.");
        SignIn();
      }
    }
    public User FindUser()
    {
      return new User();
    }


    public void OrderPizza()
    {
      OrderInterface OI = new OrderInterface(U, L);
      Order O = OI.OIMain();
      bool confirmed = ConfirmOrder(O);
      if (confirmed == true)
      {
        foreach (Pizza p in O.ItemsOnOrder)
        {
          L.ProcessPizza(p);
        }
        U.CustomerOrderHistory.Add(O);
        U.HasOrdered = true;
      }
      else //(confirmed == false)
      {
        return;
      }
    }
public void PostOrderMenu()
    {
      System.Console.WriteLine("What would you like to do? Enter a number. ");
      System.Console.WriteLine("1. View locations\n2. View order history\n3. Sign out");
      string input = System.Console.ReadLine();
      if (input == "1")
      {
        PrintLocations(ListOfLocations);
        PostOrderMenu();
      }
      else if (input == "2")
      {
        PrintOrderHistory(U);
        PostOrderMenu();
      }
      else if (input == "3")
      {
        End = true;
        return;
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please enter a number. ");
        PostOrderMenu();
      }
    }
    public void PreOrderMenu()
    {
      System.Console.WriteLine("What would you like to do? Enter a number. ");
      System.Console.WriteLine("1. View locations\n2. Select location\n3. Order a Pizza\n4. View order history\n5. Sign out");
      string input = System.Console.ReadLine();
      if (input == "1")
      {
        PrintLocations(ListOfLocations);
        PreOrderMenu();
      }
      else if (input == "2")
      {
        L = SelectLocation(ListOfLocations);
        PreOrderMenu();
      }
      else if (input == "3")
      {
        OrderPizza();
      }
      else if (input == "4")
      {
        PrintOrderHistory(U);
        PreOrderMenu();
      }
      else if (input == "5")
      {
        End = true;
        return;
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please enter a number. ");
        PreOrderMenu();
      }
    }
    public void PrintLocations(List<Location> l)
    {
      System.Console.WriteLine("These are the locations.");
      foreach (Location loc in l)
      {
          System.Console.WriteLine("Location zipcode {0}",loc.ZipCode);
      }
    }

    public void PrintOrderHistory(User U)
    {
      System.Console.WriteLine("These are your past orders.");
      foreach (Order o in U.CustomerOrderHistory)
      {
          o.PrintOrder();
      }
    }
    public Location SelectLocation(List<Location> l)
    {
      return new Location();
    }
    public bool ConfirmOrder(Order o)
    {
      o.PrintOrder();
      System.Console.WriteLine("Would you like to confirm this order?");
      string input = System.Console.ReadLine();
      if (input == "yes")
      {
        return true;
      }
      else if (input == "no")
      {
        return false;
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please answer 'yes' or 'no'.");
        return ConfirmOrder(o);
      }
    }
  }
}