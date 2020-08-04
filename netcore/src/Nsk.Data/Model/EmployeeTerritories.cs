using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nsk.Data.Model
{
    public partial class EmployeeTerritories
    {
        public int EmployeeId { get; set; }
        [MaxLength(20)]
        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
