using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }
        public int? PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
