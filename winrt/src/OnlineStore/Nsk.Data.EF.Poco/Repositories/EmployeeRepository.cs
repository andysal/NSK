using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using Nsk.Data.EF.Poco.Model;
using System.Data.Entity.Core.Objects;

namespace Nsk.Data.EF.Poco.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        protected override void AddObject(Employee item)
        {
            this.ActiveContext.Employees.AddObject(item);
        }

        protected override void DeleteObject(Employee item)
        {
            this.ActiveContext.Employees.DeleteObject(item);
        }

        protected override ObjectQuery<Employee> GetObjectQuery()
        {
            return this.ActiveContext.Employees;
        }
    }
}
