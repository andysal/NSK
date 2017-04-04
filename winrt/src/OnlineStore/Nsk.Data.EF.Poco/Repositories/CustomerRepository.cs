using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Repositories;
using Nsk.Domain.Model;
using Nsk.Data.EF.Poco.Model;
using System.Data.Entity.Core.Objects;

namespace Nsk.Data.EF.Poco.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected override void AddObject(Customer item)
        {
            this.ActiveContext.Customers.AddObject(item);
        }

        protected override void DeleteObject(Customer item)
        {
            this.ActiveContext.Customers.DeleteObject(item);
        }

        protected override ObjectQuery<Customer> GetObjectQuery()
        {
            return this.ActiveContext.Customers;
        }

        #region ICustomerRepository implementation
        public Customer FindById(string id)
        {
            return (from c in this.ActiveContext.Customers where c.Id==id select c).Single();
        }
        #endregion
    }
}
