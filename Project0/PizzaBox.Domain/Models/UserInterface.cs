using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
  public class UserInterface
  {
    public readonly TrevorDBContext _db;
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
    public Location GetLocation()
    {
      System.Console.WriteLine("Not finished here. ");
      return new Location();
    }
    public UserInterface()
    {
      ListOfLocations = new List<Location>();
      _db = new TrevorDBContext();
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
        Data.Entities.Names un = new Data.Entities.Names
        {
          FirstName = U.UserName.FirstName,
          LastName = U.UserName.LastName,
          LongName = U.UserName.LongName
        };
        L._db.Names.Add(un);
        L._db.User.Add(
        new Data.Entities.User
        {
          ZipCode = U.ZipCode,
          NameId = un.NameId
        });
        L._db.SaveChanges();
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please answer yes or no.");
        SignIn();
      }
    }
    public User FindUser()
    {
      System.Console.WriteLine("This is a work in progress.");
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
        L._db.SaveChanges();
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
        PrintLocations();
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
        PrintLocations();
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
    public void PrintLocations()
    {
      System.Console.WriteLine("These are the locations.");
      foreach (Data.Entities.Location loc in _db.Location)
      {
        System.Console.WriteLine("{0}", loc.ZipCode);
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
      System.Console.WriteLine("Still working on this. ");
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
    public int GetLocationId(Location l)
    {
      int i=0;
      foreach (Data.Entities.Location loc in _db.Location)
      {
        if (loc.ZipCode == l.ZipCode)
        {
          //i = (int)loc.ZipCode;
          return i;
        }
      }
      return (i = 0);
    }

    public int GetUserId(User u)
    {
      int i=0;
      foreach (Data.Entities.User us in L._db.User)
      {
        if (us.Name.LongName == u.UserName.LongName)
        {
          //i = (int)us.UserId;
          return i;
        }
      }
      return (i = 0);
    }
  }
}