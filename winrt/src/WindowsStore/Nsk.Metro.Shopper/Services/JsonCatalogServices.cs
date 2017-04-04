using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nsk.Metro.Shopper.Models;

namespace Nsk.Metro.Shopper.Services
{
    class JsonCatalogServices : ICatalogServices
    {
        private string baseUrl = "http://localhost:1183";

        public IEnumerable<SampleDataItem> GetProductCategories()
        {
            string url = string.Format("{0}/Catalog/GetProductCategories", baseUrl);
            HttpResponseMessage response = new HttpClient().GetAsync(url).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
                string responseString = response.Content.ReadAsStringAsync().Result;
                var categories = JsonConvert.DeserializeObject<List<ProductCategoryInfo>>(responseString);
                var categoriesDto = (from c in categories
                                     let svcUrl = string.Format("{0}/Catalog/GetImageUrlByCategoryId/{1}", baseUrl, c.Id)
                                     let json = new HttpClient().GetAsync(svcUrl).Result.Content.ReadAsStringAsync().Result
                                     let imagePath = JsonConvert.DeserializeObject<string>(json)
                                     orderby c.Name
                                     select new SampleDataItem(
                                         c.Id.ToString(),
                                         c.Name,
                                         c.Description,
                                         imagePath,
                                         c.Description,
                                         string.Empty,
                                         null
                                     )).ToList();
                return categoriesDto;
            //}
        }

        public IEnumerable<SampleDataItem> GetProductsByCategoryId(int categoryId)
        {
            string url = string.Format("{0}/Catalog/GetProductsByCategoryId?categoryId={1}", baseUrl, categoryId);
            HttpResponseMessage response = new HttpClient().GetAsync(url).Result;
            string responseString = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<ProductInfo>>(responseString);
            var products = from p in result
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
            string url = string.Format("{0}/Catalog/Search?query={1}", baseUrl, query);
            HttpResponseMessage response = new HttpClient().GetAsync(url).Result;
            string responseString = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<SearchResult>(responseString);

            var categoriesGroup = new SampleDataGroup("1", "Categories", "Product categories", string.Empty, string.Empty);
            var categories = from c in result.Categories
                             let svcUrl = string.Format("{0}/Catalog/GetImageUrlByCategoryId/{1}", baseUrl, c.Id)
                             let json = new HttpClient().GetAsync(svcUrl).Result.Content.ReadAsStringAsync().Result
                             let imagePath = JsonConvert.DeserializeObject<string>(json)
                             orderby c.Name
                             select new SampleDataItem(c.Id.ToString(), c.Name, string.Empty, imagePath, c.Description, string.Empty, categoriesGroup) { };
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

        private class ProductCategoryInfo
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        private class ProductInfo
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public decimal? UnitPrice { get; set; }
        }

        private class SearchResult
        {
            public IEnumerable<SearchResult.ProductCategoryInfo> Categories { get; set; }

            public IEnumerable<SearchResult.ProductInfo> Products { get; set; }

            public class ProductInfo
            {
                public int Id { get; set; }

                public string Name { get; set; }

                public decimal? UnitPrice { get; set; }
            }

            public class ProductCategoryInfo
            {
                public int Id { get; set; }

                public string Name { get; set; }

                public string Description { get; set; }
            }
        }
    }


}
