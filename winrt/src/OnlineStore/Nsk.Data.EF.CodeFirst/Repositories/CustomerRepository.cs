using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.EF.CodeFirst.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        #region ICustomerRepository implementation
        public Customer FindById(string id)
        {
            return (from c in this.ActiveContext.Customers where c.Id==id select c).Single();
        }
        #endregion
    }
}
