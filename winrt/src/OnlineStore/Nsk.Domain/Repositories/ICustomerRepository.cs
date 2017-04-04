using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;

namespace Nsk.Domain.Repositories
{
    /// <summary>
    /// Represents the repository of objects of type Customer
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer FindById(string id);
    }
}
