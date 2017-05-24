using System;
using System.Collections.Generic;

namespace Nsk.Data.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        //public byte[] Version { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
