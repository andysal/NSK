using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using Nsk.Web.OnlineStore.Smartphone.Models.Catalog;

namespace Nsk.Web.OnlineStore.Smartphone.WorkerServices.Catalog.Impl
{
    public class CatalogControllerWorkerServices : ICatalogControllerWorkerServices
    {
        public ICatalogServices ProductServices { get; private set; }

        public CatalogControllerWorkerServices(ICatalogServices productServices)
        {
            Contract.Requires<ArgumentNullException>(productServices != null, "productServices");

            this.ProductServices = productServices;
        }

        public Models.Catalog.ProductViewModel GetProductViewModelByProductId(int productId)
        {
            var model = (from p in this.ProductServices.GetProductsOnSale()
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
            return model;
        }
    }
}