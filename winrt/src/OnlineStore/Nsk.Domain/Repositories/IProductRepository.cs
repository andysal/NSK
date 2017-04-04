using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;

namespace Nsk.Domain.Repositories
{
    /// <summary>
    /// Represents the repository of objects of type Product
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}
