using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            Topping = new HashSet<Topping>();
        }

        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public decimal? Price { get; set; }
        public int? OrderId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Topping> Topping { get; set; }
    }
}
