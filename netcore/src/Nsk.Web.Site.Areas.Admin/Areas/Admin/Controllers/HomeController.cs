using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nsk.Web.Site.Areas.Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Home2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
