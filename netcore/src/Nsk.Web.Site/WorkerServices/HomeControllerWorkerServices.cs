using Nsk.Data.ReadModel;
using Nsk.Web.Site.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nsk.Web.Site.WorkerServices
{
    public class HomeControllerWorkerServices
    {
        public IDatabase Database { get; private set; }

        public HomeControllerWorkerServices(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));
            this.Database = database;
        }

        public IndexViewModel GetIndexViewModel()
        {
            var model = new IndexViewModel();
            model.BestSellingProducts = from p in Database
                                       .Products
                                       .ForSale()
                                       .BestSelling()
                                       .Take(4)
                                        select new Nsk.Web.Site.Models.Shared.Product
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            SupplierId = p.Supplier.Id,
                                            SupplierName = p.Supplier.CompanyName,
                                            UnitPrice = p.UnitPrice
                                        };
            model.Categories = from c in Database.Categories
                               orderby c.Name
                               select new IndexViewModel.Category
                               {
                                   Id = c.Id,
                                   Name = c.Name
                               };
            return model;
        }

        public SiteMapViewModel GetSiteMapViewModel()
        {
            var model = new SiteMapViewModel();
            model.Categories = from p in Database.Categories
                             orderby p.Name
                             select new SiteMapViewModel.Category
                             {
                                 Id = p.Id,
                                 Name = p.Name
                             };
            model.Products = from p in Database.Products.ForSale()
                             orderby p.Name
                             select new SiteMapViewModel.Product
                             {
                                 Id = p.Id,
                                 Name = p.Name
                             };
            return model;
        }

        public IEnumerable<Nsk.Web.Site.Models.Shared.Product> GetProductsByPattern(string query)
        {
            var products = Database.Products
                                .ForSale()
                                .Where(p => p.Name.StartsWith(query))
                                .Select(p => new Nsk.Web.Site.Models.Shared.Product { Id = p.Id, Name = p.Name })
                                .ToArray();
            return products;
        }
    }
}