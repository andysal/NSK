using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.Hibernate
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ISessionManagementStrategy sessionManagementStrategy)
            : base(sessionManagementStrategy)
        {
            if (sessionManagementStrategy == null)
            {
                throw new ArgumentNullException("sessionManagementStrategy");
            }
        }

        public Customer FindById(string id)
        {
            return SessionManager.GetSession().Get<Customer>(id);
        }
    }
}
