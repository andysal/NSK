using System;
using System.Collections.Generic;
using System.Text;

namespace Nsk.Domain.Model
{
    public class Region
    {
        public virtual int Id { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
