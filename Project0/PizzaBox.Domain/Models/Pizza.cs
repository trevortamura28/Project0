using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public List<Topping> PizzaToppings;
    public decimal PizzaCost;
    public Crust PizzaCrust;
    public int ToppingCount;
    public void WriteList(List<CustomerInput> A)
    {
      foreach (CustomerInput i in A)
      {
        System.Console.Write(i);
      }
    }
    public void SetPizzaCost()
    {
      decimal tcost = 0;
      switch (PizzaToppings.Count())
      {
        case 3:
          tcost = .99m;
          break;
        case 4:
          tcost = 1.99m;
          break;
        case 5:
          tcost = 2.99m;
          break;
        default:
          break;
      }
      PizzaCost = tcost + PizzaCrust.Cost;
    }
    public Pizza(Crust c, List<Topping> t)
    {
      PizzaCrust = c;
      PizzaToppings = t;
      SetPizzaCost();
    }
  }
}


