using Nsk.OnlineStore.Web.Site.Models.Catalog;
using Nsk.OnlineStore.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMate.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site.Controllers
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
        public ActionResult ProductDetail(int productId)
        {
            var model = WorkerServices.GetProductDetailViewModel(productId);
            return View(model);
        }

        [HttpGet]
        public ActionResult GetRelatedProducts(int productId)
        {
            var model = WorkerServices.GetRelatedProductsViewModel(productId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductsByCategory(int categoryId)
        {
            var model = WorkerServices.GetProductsByCategoryViewModel(categoryId);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProductsBySupplier(int supplierId)
        {
            var model = WorkerServices.GetProductsBySupplierViewModel(supplierId);
            if (model==null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            return View(model);
        }

        [HttpGet]
        //[OutputCache(Duration=30)]
        public ActionResult Rss()
        {
            var model = WorkerServices.GetRssViewModel();
            return this.Rss20(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var model = WorkerServices.GetSearchViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
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