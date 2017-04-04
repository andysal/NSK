using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Nsk.Domain.ReadModel;
using System.Web;

namespace Nsk.Metro.Services.Soap
{
    public class CatalogServices : ICatalogServices
    {
        IReadModelFacade Database;
        Nsk.Domain.Services.ICatalogServices CatalogSvc;

        public CatalogServices(IReadModelFacade database, Nsk.Domain.Services.ICatalogServices catalogServices)
        {
            Contract.Requires<ArgumentNullException>(catalogServices != null, "catalogServices");
            Contract.Requires<ArgumentNullException>(database != null, "database");
            Contract.Ensures(this.CatalogSvc == catalogServices);
            Contract.Ensures(this.Database == database);

            this.Database = database;
            this.CatalogSvc = catalogServices;
        }

        public IEnumerable<ProductCategoryInfo> GetProductCategories()
        {
            var categories = from c in Database.Categories
                                orderby c.Name
                                select new ProductCategoryInfo
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description
                                };
            return categories.ToList();
        }

        public IEnumerable<ProductInfo> GetProductsByCategoryId(int categoryId)
        {
            var products = from p in this.CatalogSvc.GetProductsOnSale()
                                where p.Category.Id == categoryId
                                orderby p.Name
                                select new ProductInfo
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    UnitPrice = p.UnitPrice
                                };
            return products.ToList();
        }

        public IEnumerable<ProductInfo> GetProductsByCategoryName(string categoryName)
        {
            var products = from p in this.CatalogSvc.GetProductsOnSale()
                            where p.Category.Name == categoryName
                            orderby p.Name
                            select new ProductInfo
                            {
                                Id = p.Id,
                                Name = p.Name,
                                UnitPrice = p.UnitPrice
                            };
            return products.ToList();
        }

        public ProductDetailInfo GetProductDetailInformations(int productId)
        {
            var product = (from p in this.CatalogSvc.GetProductsOnSale()
                           where p.Id == productId
                           select new ProductDetailInfo {
                               Id = p.Id,
                               Name = p.Name,
                               QuantityPerUnit = p.QuantityPerUnit,
                               UnitPrice = p.UnitPrice,
                               UnitsInStock = p.UnitsInStock
                           }
                           ).First();
            return product;
        }

        public SearchResult SearchInCatalog(string query)
        {
            var model = new SearchResult();
            model.Categories = (from c in Database.Categories
                                where c.Name.StartsWith(query)
                                orderby c.Name
                                select new ProductCategoryInfo
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description
                                }).ToArray();

            model.Products = (from p in this.CatalogSvc.GetProductsOnSale()
                                where p.Name.StartsWith(query)
                                orderby p.Name
                                select new ProductInfo
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    UnitPrice = p.UnitPrice
                                }).ToArray();
            return model;
        }

        public string GetImageUrlByCategoryId(int id)
        {
            string baseUrl = HttpContext.Current.Request.Headers["Host"];
            return string.Format("http://{0}/Image/GetCategoryThumbnail/{1}", baseUrl, id);
        }
    }
}
