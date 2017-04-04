using System;
using System.Collections.Generic;
using System.Text;

namespace Nsk.Domain.Model
{
    public class Territory
    {
        public Territory()
        {
            this.Employees = new List<Employee>();
        }

        public virtual string Id { get; set; }

        public virtual string Description { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
