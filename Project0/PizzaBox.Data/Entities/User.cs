using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public int NameId { get; set; }
        public int? ZipCode { get; set; }

        public virtual Names Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
