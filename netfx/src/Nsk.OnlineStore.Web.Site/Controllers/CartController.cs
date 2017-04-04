using Nsk.OnlineStore.Web.Site.Models.Cart;
using Nsk.OnlineStore.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site.Controllers
{
    public class CartController : Controller
    {
        public CartControllerWorkerServices WorkerServices { get; private set; }

        public CartController(CartControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException("workerServices");
            this.WorkerServices = workerServices;
        }

        [HttpPost]
        public ActionResult AddProduct(int productId, int quantity)
        {
            WorkerServices.PostAddProduct(productId, quantity);
            return Redirect("/Cart/Inspect");
        }

        [Authorize]
        public ActionResult Checkout()
        {
            var model = WorkerServices.GetCheckoutViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Inspect()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InspectBackendService()
        {
            var model = WorkerServices.GetInspectViewModel();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveProduct(int productId)
        {
            WorkerServices.GetRemoveProduct(productId);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public ActionResult UpdateProduct(int productId, int quantity)
        {
            WorkerServices.GetUpdateProduct(productId, quantity);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}