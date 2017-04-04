using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Nsk.Web.OnlineStore.Smartphone.Models.Catalog;
using Nsk.Web.OnlineStore.Smartphone.WorkerServices.Catalog;

namespace Nsk.Web.OnlineStore.Smartphone.Controllers
{
    public class CatalogController : Controller
    {
        public ICatalogControllerWorkerServices WorkerService { get; private set; }

        public CatalogController(ICatalogControllerWorkerServices workerService)
        {
            Contract.Requires<ArgumentNullException>(workerService != null, "workerService");

            this.WorkerService = workerService;
        }

        //[OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Product(int? id)
        {
            var model = this.WorkerService.GetProductViewModelByProductId(id.Value);

            return View(model);
        }

    }
}
