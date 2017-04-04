using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nsk.Domain.ReadModel;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using Nsk.Web.OnlineStore.Models.Catalog;
using System.ServiceModel.Syndication;

namespace Nsk.Web.OnlineStore.WorkerServices.Impl
{
    public class CatalogControllerWorkerServices : ICatalogControllerWorkerServices
    {
        public ICatalogServices CatalogServices { get; private set; }
        public IReadModelFacade ReadModelFacade { get; private set; }

        public CatalogControllerWorkerServices(IReadModelFacade readModelFacade, ICatalogServices catalogServices)
        {
            Contract.Requires<ArgumentNullException>(catalogServices != null, "catalogServices");
            Contract.Requires<ArgumentNullException>(readModelFacade != null, "readModelFacade");
            Contract.Ensures(this.CatalogServices == catalogServices);
            Contract.Ensures(this.ReadModelFacade == readModelFacade);

            this.ReadModelFacade = readModelFacade;
            this.CatalogServices = catalogServices;
        }

        public SearchViewModel GetSearchPageViewModel(int categoryId, string query)
        {
            var model = new SearchViewModel();
            model.Categories = (from c in this.ReadModelFacade.Categories 
                               where c.Name.StartsWith(query) 
                               orderby c.Name 
                               select new SearchViewModel.ProductCategoryDescriptor { Name = c.Name }).ToList();

            var products = from p in this.CatalogServices.GetAvailableProductsOnSale()
                           where p.Name.StartsWith(query)
                           select p;
            if (categoryId > 0)
            {
                products = products.Where(p => p.Category.Id == categoryId);
            }
            model.Products = (from p in products
                             orderby p.Name                              
                             select new SearchViewModel.ProductInfo { 
                                        Id=p.Id, 
                                        Name = p.Name, 
                                        Price = p.UnitPrice.Value, 
                                        UnitsInStock = p.UnitsInStock.Value })
                                        .ToList();

            return model;
        }

        public ProductViewModel GetProductViewModelByProductId(int productId)
        {
            ProductViewModel model = (from p in this.CatalogServices.GetProductsOnSale()
                                        let detail = new ProductViewModel.ProductDescriptor
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            UnitPrice = p.UnitPrice.Value,
                                            UnitsInStock = p.UnitsInStock.Value,
                                            QuantityPerUnit = p.QuantityPerUnit
                                        }
                                        where p.Id == productId
                                        select new ProductViewModel
                                        {
                                            ProductDetail = detail,
                                            Title = p.Name + " - " + p.Category.Name + " - " + p.Supplier.Name + " - NSK",
                                            KeyWords = p.Name + ", " + p.Category.Name + ", " + p.Supplier.Name
                                        }).First();

            model.RelatedProducts = (from p in this.CatalogServices.GetRelatedProducts(productId)
                                     orderby p.Name
                                     select new ProductViewModel.RelatedProductDescriptor
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         UnitPrice = p.UnitPrice.Value,
                                         UnitsInStock = p.UnitsInStock.Value
                                     }).Take(5).AsEnumerable();
            return model;
        }

        public ProductCategoryViewModel GetProductCategoryViewModelByCategoryName(string categoryName, string sort)
        {
            var model = new ProductCategoryViewModel();

            model.Title = string.Format("{0} - NSK", categoryName);
            model.CategoryName = categoryName;

            ProductCategoryViewModel.SortingCriterion criterion = ProductCategoryViewModel.SortingCriterion.CreateCriterionByName(sort);
            model.SelectedSortingCriterionName = criterion.CriterionName;

            model.Products = criterion.Sort( 
                                from p in this.CatalogServices.GetAvailableProductsOnSale()
                                where p.Category.Name == categoryName
                                select new ProductCategoryViewModel.ProductInfo
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Price = p.UnitPrice.Value,
                                        SupplierName = p.Supplier.Name,
                                        UnitsInStock = p.UnitsInStock.Value
                                    }
                                );           

            return model;
        }

        public AddToShoppingCartViewModel BuildAddToShoppingCartViewModel()
        {
            var quantities = new List<SelectListItem>()
                                {
                                    new SelectListItem() { Text="1", Value="1", Selected=true},
                                    new SelectListItem() { Text="2", Value="2", Selected=true}
                                };
            AddToShoppingCartViewModel model = new AddToShoppingCartViewModel();
            //model.Quantity;
            model.SelectableQuantities = new SelectList(quantities, "Value", "Text", quantities[0]);
            return model;
        }
    }
}