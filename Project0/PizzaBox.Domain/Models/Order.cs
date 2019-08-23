using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Order 
    {
      public List<Pizza> ItemsOnOrder = new List<Pizza>();
      public decimal TotalPrice;
      public decimal  MAXPRICE=5000;
      public int MAXITEMS=100;

      public void CalculateCost ()
      {
        decimal price=0;
        foreach(Pizza pizza in ItemsOnOrder)
        {
          pizza.SetPizzaCost();
          price= price + pizza.PizzaCost;
        }
        TotalPrice= price;
      }

      public void PrintOrder()
      {
        foreach(Pizza p in ItemsOnOrder)
        {
          int count=0;
          System.Console.Write("A {0} pizza with {1} crust. ", p.PizzaCrust.CrustSize.Name, p.PizzaCrust.Name);
          if (p.PizzaToppings==null)
          {
            System.Console.Write("\n");
          }
          foreach(Topping t in p.PizzaToppings)
          {
            if ((p.ToppingCount > 1) && (count==0))
            {
              System.Console.Write("Its toppings are {0}, ", t.Name);
              count++;
            }
            else if (count==(p.ToppingCount-1) && (count>0))
            {
              System.Console.Write("and {0}.\n",t.Name);
            }
            else
            {
              System.Console.Write("{0}, ", t.Name);
              count++;
            }
          }
        }
      }

      
    }

}