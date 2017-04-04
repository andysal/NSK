using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site.Areas.My.Controllers
{
    public class HomeController : Controller
    {
        // GET: My/Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}