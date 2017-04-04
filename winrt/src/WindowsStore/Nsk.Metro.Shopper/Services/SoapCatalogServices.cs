
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nsk.Metro.Shopper.Models;
using Nsk.Metro.Shopper.Soap;
using System.Diagnostics.Contracts;
using System.ServiceModel;

namespace Nsk.Metro.Shopper.Services
{
    class SoapCatalogServices : ICatalogServices
    {
        CatalogServicesClient Service = null;

        public SoapCatalogServices()
        {
            Contract.Ensures(this.Service != null);

            this.Service = new CatalogServicesClient();
        }

        public IEnumerable<SampleDataItem> GetProductCategories()
        {
            var categories = this.Service.GetProductCategoriesAsync().Result;
            var categoriesDto = (from c in categories
                                 orderby c.Name
                                 select new SampleDataItem(
                                     c.Id.ToString(),
                                     c.Name,
                                     c.Description,
                                     this.Service.GetImageUrlByCategoryIdAsync(c.Id).Result,
                                     c.Description,
                                     string.Empty,
                                     null
                                 )).ToList();
            return categoriesDto;
        }

        public IEnumerable<SampleDataItem> GetProductsByCategoryId(int categoryId)
        {
            var products = from p in this.Service.GetProductsByCategoryIdAsync(categoryId).Result
                           orderby p.Name
                           select new SampleDataItem(
                                          p.Id.ToString(),
                                          p.Name,
                                          p.UnitPrice.ToString(),
                                          string.Empty,
                                          string.Empty,
                                          string.Empty,
                                          null
                                      );
            return products;
        }

        public IEnumerable<SampleDataGroup> Search(string query)
        {
            var result = this.Service.SearchInCatalogAsync(query).Result;

            var categoriesGroup = new SampleDataGroup("1", "Categories", "Product categories", string.Empty, string.Empty);
            var categories = from c in result.Categories
                             orderby c.Name
                             select new SampleDataItem(c.Id.ToString(), c.Name, string.Empty, this.Service.GetImageUrlByCategoryIdAsync(c.Id).Result, c.Description, string.Empty, categoriesGroup) { };
            categoriesGroup.SetItems(categories);

            var productsGroup = new SampleDataGroup("2", "Products", "Products", string.Empty, string.Empty);
            var products = from c in result.Products
                           orderby c.Name
                           select new SampleDataItem(c.Id.ToString(), c.Name, string.Empty, string.Empty, string.Empty, string.Empty, productsGroup) { };
            productsGroup.SetItems(products);

            var groups = new ObservableCollection<SampleDataGroup>() { 
                                                                        categoriesGroup,
                                                                        productsGroup 
                                                                     };
            return groups;
        }
    }
}
