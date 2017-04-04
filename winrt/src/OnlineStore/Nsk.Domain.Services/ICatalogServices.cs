using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.ReadModel;

namespace Nsk.Domain.Services
{
    public interface ICatalogServices
    {
        IQueryable<Product> GetProductsOnSale();
        IQueryable<Product> GetAvailableProductsOnSale();
        IQueryable<Product> GetRelatedProducts(int productId);
    }
}
