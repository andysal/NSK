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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected override void AddObject(Product item)
        {
            this.ActiveContext.Products.AddObject(item);
        }

        protected override void DeleteObject(Product item)
        {
            this.ActiveContext.Products.DeleteObject(item);
        }

        protected override ObjectQuery<Product> GetObjectQuery()
        {
            return this.ActiveContext.Products;
        }
    }
}
