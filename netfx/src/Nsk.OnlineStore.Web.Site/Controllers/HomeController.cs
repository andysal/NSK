using Nsk.OnlineStore.Web.Site.Models.Home;
using Nsk.OnlineStore.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeControllerWorkerServices WorkerServices { get; private set; }

        public HomeController(HomeControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException("workerServices");
            this.WorkerServices = workerServices;
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public ActionResult Index()
        {
            var model = WorkerServices.GetIndexViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult GetProductsByPattern(string query)
        {
            var model = WorkerServices.GetProductsByPattern(query);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 30)]
        public ActionResult SiteMap()
        {
            var model = WorkerServices.GetSiteMapViewModel();
            return View(model);
        }
    }
}