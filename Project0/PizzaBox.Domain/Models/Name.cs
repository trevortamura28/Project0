using System;

namespace PizzaBox.Domain.Models
{
    public class Name
    {
      public string FirstName;
      public string LastName;
      public string LongName;

      public void SetLongName()
      {
        LongName=FirstName+LastName;
      }
    }
}