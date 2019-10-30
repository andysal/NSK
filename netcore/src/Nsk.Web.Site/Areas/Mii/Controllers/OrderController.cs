using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Nsk.Web.Site.Areas.Mii.Models.Order;

namespace Nsk.Web.Site.Areas.Mii.Controllers
{
    [Area("Mii")]
    //[Authorize]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Current()
        {
            var model = new CurrentViewModel();
            return View(model);
        }
    }
}