using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
  public class Location
  {
    public readonly TrevorDBContext _db;
    public Inventory Stock;
    public int ZipCode;
    public List<Topping> PizzaToppingsOffered;
    public Dictionary<string, User> PreviousCustomers;
    public List<Order> StoreOrderHistory;

    public Location()
    {

      _db = new TrevorDBContext();
      PizzaToppingsOffered = new List<Topping>();
      PreviousCustomers = new Dictionary<string, User>();
      StoreOrderHistory = new List<Order>();
      FirstLocation();
    }
    public void AddNewCustomer(User newCustomer)
    {
      PreviousCustomers.Add(newCustomer.UserName.LongName, newCustomer);
    }
    public void ProcessPizza(Pizza p)
    {
      Data.Entities.Pizza ph = new Data.Entities.Pizza { };
      ph.Crust = new Data.Entities.Crust
      {
        Name = p.PizzaCrust.Name,
        Size = new Data.Entities.Size
        {
          Name = p.PizzaCrust.CrustSize.Name
        }
      };
      
      ph.Price = p.PizzaCost;
      _db.Pizza.Add(ph);
      foreach (Topping t in p.PizzaToppings)
      {
        Data.Entities.Topping tt = new Data.Entities.Topping
        {
          PizzaId = ph.PizzaId,
          Name = t.Name
        };
        _db.Topping.Add(tt);
      }
      _db.SaveChanges();
    }

    public void FirstLocation()
    {
      PizzaToppingsOffered.Add(new Topping("pepperoni"));
      PizzaToppingsOffered.Add(new Topping("ham"));
      PizzaToppingsOffered.Add(new Topping("bacon"));
      PizzaToppingsOffered.Add(new Topping("sausage"));
      PizzaToppingsOffered.Add(new Topping("mushrooms"));
      PizzaToppingsOffered.Add(new Topping("onions"));
      PizzaToppingsOffered.Add(new Topping("green peppers"));
      PizzaToppingsOffered.Add(new Topping("red peppers"));
  
    }
  }
}