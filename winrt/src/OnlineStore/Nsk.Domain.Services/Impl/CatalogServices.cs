using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using Nsk.Domain.ReadModel;

namespace Nsk.Domain.Services.Impl
{
    public class CatalogServices : ICatalogServices
    {
        public IReadModelFacade ReadModelFacade { get; set; }

        public CatalogServices(IReadModelFacade readModelFacade)
        {
            Contract.Requires<ArgumentNullException>(readModelFacade != null, "readModelFacade");
            Contract.Ensures(this.ReadModelFacade == readModelFacade, "readModelFacade");

            this.ReadModelFacade = readModelFacade;
        }

        public IQueryable<Product> GetProductsOnSale()
        {
            return from p in this.ReadModelFacade.Products 
                   where p.IsDiscontinued == false 
                   select p;
        }

        public IQueryable<Product> GetAvailableProductsOnSale()
        {
            return from p in GetProductsOnSale() 
                   where p.UnitsInStock > 0 
                   select p;
        }

        public IQueryable<Product> GetRelatedProducts(int productId)
        {
            int categoryId = (from pd in this.GetProductsOnSale() where pd.Id == productId select pd.Category.Id).Single();
            return from p in GetAvailableProductsOnSale()
                   where p.Id!=productId && p.Category.Id == categoryId 
                   select p;
        }
    }
}
