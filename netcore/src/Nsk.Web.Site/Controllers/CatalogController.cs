using Microsoft.AspNetCore.Mvc;
using Nsk.Web.Site.Models.Catalog;
using Nsk.Web.Site.WorkerServices;
using System;
using MvcMate2.Mvc;

namespace Nsk.Web.Site.Controllers
{
    public class CatalogController : Controller
    {
        public CatalogControllerWorkerServices WorkerServices { get; private set; }

        public CatalogController(CatalogControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException("workerServices");
            this.WorkerServices = workerServices;
        }

        [HttpGet]
        public IActionResult ProductDetail(int productId)
        {
            var model = WorkerServices.GetProductDetailViewModel(productId);
            return View(model);
        }

        [HttpGet]
        public IActionResult GetRelatedProducts(int productId)
        {
            var model = WorkerServices.GetRelatedProductsViewModel(productId);
            return Json(model);
        }

        [HttpGet]
        public IActionResult ProductsByCategory(int categoryId)
        {
            var model = WorkerServices.GetProductsByCategoryViewModel(categoryId);
            return View(model);
        }

        [HttpGet]
        public IActionResult ProductsBySupplier(int supplierId)
        {
            var model = WorkerServices.GetProductsBySupplierViewModel(supplierId);
            if (model==null)
                return new StatusCodeResult(400);
            return View(model);
        }

        [HttpGet]
        //[OutputCache(Duration=30)]
        public IActionResult Rss()
        {
            var model = WorkerServices.GetRssViewModel();
            return this.Rss(model);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var model = WorkerServices.GetSearchViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model = WorkerServices.PostSearchViewModel(model);
            return View(model);
        }
    }
}