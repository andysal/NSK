using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nsk.Data.Model
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
        }

        [MaxLength(20)]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int RegionId { get; set; }

        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual Region Region { get; set; }
    }
}
