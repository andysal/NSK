using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nsk.Web.Site.WorkerServices;
using Nsk.Web.Site.Models.Home;

namespace Nsk.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeControllerWorkerServices WorkerServices { get; private set; }

        public HomeController(HomeControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException(nameof(workerServices));
            this.WorkerServices = workerServices;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IActionResult Index()
        {
            var model = WorkerServices.GetIndexViewModel();
            return View(model);
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Nsk.Web.Site.Models.Shared.Product> GetProductsByPattern(string query)
        {
            var model = WorkerServices.GetProductsByPattern(query);
            return model;
        }

        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("sitemap")]
        public IActionResult SiteMap()
        {
            ControllerContext.HttpContext.Response.ContentType = "application/xml";
            var model = WorkerServices.GetSiteMapViewModel();
            return View(model);
        }
    }
}
