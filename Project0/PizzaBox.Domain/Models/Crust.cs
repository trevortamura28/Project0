using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Crust : CustomerInput
  {
    public Size CrustSize;
    public void SetCrustCost()
    {
      decimal crustTypeCost = 0;
      if (Name == "cheesy")
      {
        crustTypeCost=1.99m;
      }
      Cost = CrustSize.Cost + crustTypeCost;
    }
    public Crust(string n, Size s)
    {
      Name = n;
      CrustSize = s;
      SetCrustCost();
    }
  }
}