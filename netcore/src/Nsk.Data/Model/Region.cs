using System;
using System.Collections.Generic;

namespace Nsk.Data.Model
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
