using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class OrderInterface : CustomerInterface
  {
    public Order OIMain()
    {
      Order o= new Order();
      bool cont = true; bool testInput = false;
      string input=null;

      System.Console.WriteLine("Hello, I am here to take your order. ");
      do
      {
        Pizza p = new Pizza(GetCrust(GetSize()),GetTopping(L.PizzaToppingsOffered));
        if((p.PizzaCost + o.TotalPrice > o.MAXPRICE) || (o.ItemsOnOrder.Count +1 > o.MAXITEMS))
        {
          System.Console.WriteLine("This pizza takes you over the maximum order price or over the maximum item limit.");
        }
        else if((p.PizzaCost + o.TotalPrice <= o.MAXPRICE) && (o.ItemsOnOrder.Count <= o.MAXITEMS-1))
        {
          o.ItemsOnOrder.Add(p);
          p.ToppingCount=p.PizzaToppings.Count;
          o.CalculateCost();
        }
        testInput=false;
        while(testInput == false)
        {
          System.Console.WriteLine("Your total cost is {0}. Would you like another pizza? ", o.TotalPrice);
          input = System.Console.ReadLine();
          if(input == "yes" || input == "no")
          {
            testInput=true;
          }
          else
          {
            System.Console.WriteLine("Invalid input. Please enter: 'yes' or 'no'. ");
          }
        }
      if(input == "no")
      {
        cont=false;
      }
      }while(cont==true);
      return o;
    }
    public OrderInterface(User u, Location l) 
    {
      U = u;
      L = l;
    }

  }
}
