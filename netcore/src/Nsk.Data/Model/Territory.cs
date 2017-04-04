using System;
using System.Collections.Generic;

namespace Nsk.Data.Model
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }

        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual Region Region { get; set; }
    }
}
