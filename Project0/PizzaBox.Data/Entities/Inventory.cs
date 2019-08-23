using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string Item { get; set; }
        public int? Stock { get; set; }
        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
