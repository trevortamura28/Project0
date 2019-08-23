using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Size
    {
        public Size()
        {
            Crust = new HashSet<Crust>();
        }

        public int SizeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Crust> Crust { get; set; }
    }
}
