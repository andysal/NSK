using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.Hibernate
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ISessionManagementStrategy sessionManagementStrategy)
            : base(sessionManagementStrategy)
        {
            if (sessionManagementStrategy == null)
            {
                throw new ArgumentNullException("sessionManagementStrategy");
            }
        }
    }
}
