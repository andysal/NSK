using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using Nsk.Domain.Repositories;
using Nsk.Web.OnlineStore.Smartphone.Models.Home;
using Nsk.Domain.Services;

namespace Nsk.Web.OnlineStore.Smartphone.WorkerServices.Home.Impl
{
    public class HomeControllerWorkerServices : IHomeControllerWorkerServices
    {
        public ICatalogServices CatalogServices { get; private set; }

        public HomeControllerWorkerServices(ICatalogServices catalogServices)
        {
            Contract.Requires<ArgumentNullException>(catalogServices!=null);
            Contract.Ensures(this.CatalogServices == catalogServices);

            this.CatalogServices = catalogServices;
        }

        public IndexViewModel GetIndexViewModel()
        {
            IndexViewModel model = new IndexViewModel();
            model.RecommendedProduct = (from p in this.CatalogServices.GetAvailableProductsOnSale()
                                         orderby p.UnitsInStock descending
                                         select new IndexViewModel.ProductDescriptor
                                         {
                                             Id = p.Id,
                                             Name = p.Name,
                                             UnitPrice = p.UnitPrice.Value,
                                             SupplierName = p.Supplier.Name
                                         }).Take(1).Single();

            return model;
        }

        public bool UserNameIsAlreadyUsed(string userName)
        {
            return userName == "andysal74";
        }
    }
}