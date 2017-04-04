using Nsk.OnlineStore.Data.ReadModel;
using Nsk.OnlineStore.Web.Site.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.OnlineStore.Web.Site.WorkerServices
{
    public class HomeControllerWorkerServices
    {
        public IDatabase Database { get; private set; }

        public HomeControllerWorkerServices(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            this.Database = database;
        }

        public IndexViewModel GetIndexViewModel()
        {
            var model = new IndexViewModel();
            model.BestSellingProducts = from p in Database
                                       .Products
                                       .BestSelling()
                                       .Take(4)
                                        select new IndexViewModel.Product
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
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

        public IEnumerable<IndexViewModel.Product> GetProductsByPattern(string query)
        {
            var products = Database.Products
                                .ForSale()
                                .Where(p => p.Name.StartsWith(query))
                                .Select(p => new IndexViewModel.Product { Id = p.Id, Name = p.Name })
                                .ToArray();
            return products;
        }
    }
}