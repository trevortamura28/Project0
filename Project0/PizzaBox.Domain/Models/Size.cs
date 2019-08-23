using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : CustomerInput
  {
    public void SetCost()
    {
      switch (Name)
      {
        case "small":
          Cost = 7.99m;
          break;
        case "medium":
          Cost = 8.99m;
          break;
        case "large":
          Cost = 9.99m;
          break;
        default:
          Console.WriteLine("Pizza size Invalid.");
          break;
      }
    }
    public Size(string s)
    {
      Name = s;
      SetCost();
    }
  }
}