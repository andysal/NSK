using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Web;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using Nsk.Domain.ReadModel;
using Nsk.Web.OnlineStore.Models.Home;

namespace Nsk.Web.OnlineStore.WorkerServices.Impl
{
    public class HomeControllerWorkerServices : IHomeControllerWorkerServices
    {
        private int itemCount = 9;
        public IReadModelFacade ReadModelFacade { get; private set; }
        public ICatalogServices CatalogServices { get; private set; }

        public HomeControllerWorkerServices(ICatalogServices catalogServices, IReadModelFacade readModelFacade)
        {
            Contract.Requires<ArgumentNullException>(catalogServices != null, "catalogServices");
            Contract.Requires<ArgumentNullException>(readModelFacade != null, "readModelFacade");

            this.CatalogServices = catalogServices;
            this.ReadModelFacade = readModelFacade;          
        }

        public IEnumerable<ProductCategoriesViewModel.ProductCategoryDescriptor> GetAllProductCategories()
        {
            var descriptors = (from c in this.ReadModelFacade.Categories
                                let count = c.Products.Count()
                                let AvailableProdCount = (from p in c.Products where p.UnitsInStock > 0 select p).Count()
                                orderby c.Name, c.Id
                               select new ProductCategoriesViewModel.ProductCategoryDescriptor 
                                {   
                                    CategoryId = c.Id, 
                                    CategoryName = c.Name,
                                    ProductsCount = count,
                                    AvailableProductsCount = AvailableProdCount 
                                });
            return descriptors;
        }

        public IEnumerable<ProductCategoriesViewModel.ProductCategoryDescriptor> GetBestSellingProductCategories()
        {
            return GetAllProductCategories().OrderBy(c => c.AvailableProductsCount);
            //var descriptors = (from d in
            //                       (from o in this.OrderRepository select o).SelectMany(o => o.Items)
            //                   group d by d.Product.Category into d
            //                   select new
            //                   {
            //                       CategoryId = d.Key.Id,
            //                       CategoryName = d.Key.Name,
            //                       ProductsCount = d.Key.Products.Where(p => p.Category.Id == d.Key.Id).Count(),
            //                       AvailableProductsCount = d.Key.Products.Where(p => p.UnitsInStock > 0).Count(),
            //                       TotalSales = d.Sum(dt => dt.Quantity)
            //                   })
            //                   .OrderByDescending(d => d.TotalSales)
            //                   .Select(
            //                        d => new ProductCategoryDescriptor
            //                        {
            //                            CategoryId = d.CategoryId,
            //                            CategoryName = d.CategoryName,
            //                            ProductsCount = d.ProductsCount,
            //                            AvailableProductsCount = d.AvailableProductsCount
            //                        }
            //                   );
            //return descriptors;
        }

        public Image GetThumbnailForCategoryId(int categoryId)
        {
            return this.ReadModelFacade.GetThumbnailByCategory(categoryId);
        }

        public IndexViewModel GetIndexViewModel()
        {
            IndexViewModel model = new IndexViewModel();
            model.RecommendedProducts = (from p in this.CatalogServices.GetAvailableProductsOnSale()
                                           orderby p.UnitsInStock descending
                                           select new IndexViewModel.ProductDescriptor
                                              {
                                                  Id = p.Id,
                                                  Name = p.Name,
                                                  UnitPrice = p.UnitPrice.Value,
                                                  UnitsInStock = p.UnitsInStock.Value,
                                              }).Take(3);
            
            return model;
        }

        public bool UserNameIsAlreadyUsed(string userName)
        {
            return userName == "andysal74";
        }
    }
}