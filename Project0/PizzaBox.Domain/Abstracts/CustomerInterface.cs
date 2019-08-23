using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class CustomerInterface
  {
    public User U;
    public Location L;

    public List<Topping> AddTopping(List<Topping> t)
    {
      System.Console.Write("What would you like to add? We offer "); PrintToppings(L.PizzaToppingsOffered);
      string input = System.Console.ReadLine();
      if ((L.PizzaToppingsOffered.Any(i => i.Name == input)))
      {
        t.Add(SetTopping(input));
      }
      else
      {
        System.Console.WriteLine("Invalid input.");
      }
      if(t.Count<2)
      {
        AddTopping(t);
      }
      return t;
  }
  public List<Topping> GetTopping(List<Topping> l)
  {
    List<Topping> t = new List<Topping>();
    int tCount = 0;
    bool cont = true;
    t= AddTopping(t);
    while (cont == true)
    {
      System.Console.WriteLine("Would you like to add another topping? ");
      string c = System.Console.ReadLine();
      switch (c)
      {
        case "yes":
          t=AddTopping(t);
          break;
        case "no":
          cont = false;
          break;
        default:
          System.Console.WriteLine("Invalid input. ");
          break;
      }
      tCount = t.Count;
      if (t.Count == 5)
      {
        System.Console.WriteLine("You have reached the maximum number of toppings.");
        cont = false;
      }
    }
    return t;
  }
  public Crust GetCrust(Size s)
  {
    bool cont = true;
    string input = null;
    while (cont == true)
    {
      System.Console.WriteLine("We make original, thin, and cheesy crust pizzas. What type of crust would you like? ");
      input = System.Console.ReadLine();
      if (input == "original" || input == "thin" || input == "cheesy")
      {
        cont = false;
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please enter: 'original', 'thin', or 'cheesy'.");
      }
    }
    return new Crust(input, s);
  }
  public Size GetSize()
  {
    bool cont = true;
    string input = null;
    while (cont == true)
    {
      System.Console.WriteLine("We serve small, medium, and large pizzas. What size pizza would you like? ");
      input = System.Console.ReadLine();
      if (input == "small" || input == "medium" || input == "large")
      {
        cont = false;
      }
      else
      {
        System.Console.WriteLine("Invalid input. Please enter: 'small', 'medium', or 'large'.");
      }
    }
    return new Size(input);
  }
  public Topping SetTopping(string i)
  {
    Topping t = new Topping(i);
    return t;
  }
  public void PrintToppings(List<Topping> l)
  {
    int count = 0;
    foreach (Topping t in l)
    {
      if (count == l.Count - 1)
        Console.Write("and " + t.Name + ".\n");
      else
        Console.Write(t.Name + ", ");
      count++;
    }
  }
}
}