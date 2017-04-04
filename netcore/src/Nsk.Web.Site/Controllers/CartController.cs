using Nsk.Web.Site.Models.Cart;
using Nsk.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Nsk.Web.Site.Controllers
{
    public class CartController : Controller
    {
        public CartControllerWorkerServices WorkerServices { get; private set; }

        public CartController(CartControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException(nameof(workerServices));
            this.WorkerServices = workerServices;
        }

        [HttpPost]
        public IActionResult AddProduct(int productId, int quantity)
        {
            WorkerServices.PostAddProduct(productId, quantity);
            return Redirect("/Cart/Inspect");
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var model = WorkerServices.GetCheckoutViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Inspect()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InspectBackendService()
        {
            var model = WorkerServices.GetInspectViewModel();
            return Json(model);
        }

        [HttpGet]
        public IActionResult RemoveProduct(int productId)
        {
            WorkerServices.GetRemoveProduct(productId);
            return Ok();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int productId, int quantity)
        {
            WorkerServices.GetUpdateProduct(productId, quantity);
            return Ok();
        }
    }
}