using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMate2.Mvc.Model;
using Nsk.Data.ReadModel;
using Nsk.Web.Site.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nsk.Web.Site.WorkerServices
{
    public class CatalogControllerWorkerServices
    {
        public IDatabase Database { get; private set; }

        public CatalogControllerWorkerServices(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            this.Database = database;
        }

        public SearchViewModel GetSearchViewModel()
        {
            var model = new SearchViewModel();
            PopulateCategories(model);
            return model;
        }

        public SearchViewModel PostSearchViewModel(SearchViewModel model)
        {
            PopulateCategories(model);
            var repo = Database.Products.ForSale();
            if(model.SelectedCategoryId > 0 )
            {
                repo = repo.ByCategory(model.SelectedCategoryId);
            }
            if (model.MaxUnitPrice.HasValue)
            {
                repo = repo.Where(p => p.UnitPrice <= model.MaxUnitPrice);
            }
            if(model.MinUnitPrice.HasValue)
            {
                repo = repo.Where(p => p.UnitPrice >= model.MinUnitPrice);
            }
            repo = repo.Where(p => p.Name.StartsWith(model.Query));
            model.Products = (from p in repo
                            orderby p.Name
                            select new SearchViewModel.Product
                            {
                                Id = p.Id,
                                Name = p.Name,
                                CategoryName = p.Category.Name,
                                SupplierName = p.Supplier.CompanyName,
                                UnitPrice = p.UnitPrice
                            }).Take(12);
           
            return model;
        }

        public ProductDetailViewModel GetProductDetailViewModel(int productId)
        {
            var model = (from p in Database.Products.ForSale()
                         where p.Id == productId
                         select new ProductDetailViewModel()
                         {
                             Id = p.Id,
                             CategoryId = p.CategoryId.Value,
                             CategoryName = p.Category.Name,
                             Name = p.Name,
                             QuantityPerUnit = p.QuantityPerUnit,
                             SupplierId = p.SupplierId.Value,
                             SupplierName = p.Supplier.CompanyName,
                             UnitsInStock = p.UnitsInStock.Value,
                             UnitPrice = p.UnitPrice.Value
                         }).SingleOrDefault();
            model.RelatedProducts = from rp in Database.Products
                                        .ForSale()
                                        .ByCategory(model.CategoryId)
                                        .BySupplier(model.SupplierId) 
                                    where rp.Id != productId 
                                    orderby rp.UnitsInStock descending 
                                    select new ProductDetailViewModel.RelatedProduct() { 
                                        Id = rp.Id, 
                                        Name = rp.Name, 
                                        UnitPrice = rp.UnitPrice.Value 
                                    };
            return model;
        }

        public IEnumerable<ProductDetailViewModel.RelatedProduct> GetRelatedProductsViewModel(int productId)
        {
            var product = (from p in Database.Products
                          where p.Id == productId
                          select new { 
                              CategoryId = p.CategoryId.Value,
                              SupplierId = p.SupplierId.Value
                          })
                          .SingleOrDefault();
            if(product==null)
            {
                return new List<ProductDetailViewModel.RelatedProduct>();
            }
            else
            {
                var products = from rp in Database.Products
                                            .ForSale()
                                            .ByCategory(product.CategoryId)
                                            .BySupplier(product.SupplierId)
                               where rp.Id != productId
                               orderby rp.UnitsInStock descending
                               select new ProductDetailViewModel.RelatedProduct()
                               {
                                   Id = rp.Id,
                                   Name = rp.Name,
                                   UnitPrice = rp.UnitPrice.Value
                               }; ;

                return products;
            }
        }

        public ProductsByCategoryViewModel GetProductsByCategoryViewModel(int categoryId)
        {
            var model = (from c in Database.Categories
                        where c.Id == categoryId
                        select new ProductsByCategoryViewModel { 
                            CategoryId = c.Id,
                            CategoryName = c.Name
                        }).SingleOrDefault();
            if(model!=null)
            {
                model.Products = from p in Database.Products.ForSale().ByCategory(categoryId)
                                 orderby p.Name
                                 select new Nsk.Web.Site.Models.Shared.Product
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     SupplierId = p.SupplierId.Value,
                                     SupplierName = p.Supplier.CompanyName,
                                     UnitPrice = p.UnitPrice.Value
                                 };
            }

            return model;
        }

        public ProductsBySupplierViewModel GetProductsBySupplierViewModel(int supplierId)
        {
            var model = (from c in Database.Suppliers
                         where c.Id == supplierId
                         select new ProductsBySupplierViewModel
                         {
                             SupplierId = c.Id,
                             SupplierName = c.CompanyName
                         }).SingleOrDefault();
            if (model != null)
            {
                model.Products = from p in Database.Products.ForSale().BySupplier(supplierId)
                                 orderby p.Name
                                 select new ProductsBySupplierViewModel.Product
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     CategoryId = p.CategoryId.Value,
                                     CategoryName = p.Category.Name,
                                     UnitPrice = p.UnitPrice.Value
                                 };
            }

            return model;
        }

        public SyndicationFeed GetRssViewModel()
        {
            var items = new List<SyndicationItem>();
            var products = from p in Database.Products.ForSale()
                           select new
                           {
                               p.Id,
                               p.Name,
                               p.QuantityPerUnit,
                               p.UnitPrice,
                               CategoryName = p.Category.Name,
                               CategoryId = p.CategoryId
                           };
            foreach (var p in products)
            {
                var contentString = string.Format("Quantity per unit: {0} - Unit Price: {1:0.00}", p.QuantityPerUnit, p.UnitPrice);
                //var content = new TextSyndicationContent(contentString);
                var item = new SyndicationItem(p.Name, contentString);
                //item.Categories.Add(new SyndicationCategory(p.CategoryName));
                //item.Title = new TextSyndicationContent(p.Name, TextSyndicationContentKind.Plaintext);
                //item.BaseUri = new Uri(UrlBuilder.BuildProductPageUrl(p.Id, p.Name), UriKind.Relative);
                //item.LastUpdatedTime = DateTime.Now;
                //item.Summary = content;
                //item.Content = content;
                items.Add(item);
            }

            var feed = new SyndicationFeed("NSK Online Store product catalog")
            {
                Items = items
            };
            //feed.Title = new TextSyndicationContent("NSK Online Store product catalog");
            feed.LastUpdatedTime = DateTime.Now;
            return feed;
        }

        private void PopulateCategories(SearchViewModel model)
        {
            var categories = (from c in Database.Categories
                                select new SelectListItem
                                {
                                    Value = c.Id.ToString(),
                                    Text = c.Name
                                }).ToList();
            categories.Add(new SelectListItem() { 
                                    Text = "All Categories",
                                    Value = "0"
                                });
            model.Categories = categories.OrderBy(c => c.Text);
        }
    }
}