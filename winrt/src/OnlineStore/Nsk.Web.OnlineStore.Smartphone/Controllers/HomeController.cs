using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nsk.Web.Mvc;
using Nsk.Web.OnlineStore.Smartphone.Models.Home;
using Nsk.Web.OnlineStore.Smartphone.WorkerServices.Home;

namespace Nsk.Web.OnlineStore.Smartphone.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public IHomeControllerWorkerServices WorkerService { get; private set; }

        public HomeController(IHomeControllerWorkerServices workerService)
        {
            Contract.Requires<ArgumentNullException>(workerService != null, "workerService");
            Contract.Ensures(this.WorkerService == workerService);

            this.WorkerService = workerService;
        }

        //[Minify(ApplyCompression=true, RemoveWhiteSpace=true)]
        public ActionResult Index()
        {
            var model = this.WorkerService.GetIndexViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel() { BirthDate = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public JsonResult ValidateUniqueUserName(string UserName)
        {
            bool userAlreadyExists = this.WorkerService.UserNameIsAlreadyUsed(UserName);
            return Json(!userAlreadyExists, JsonRequestBehavior.AllowGet);
        }
    }
}
