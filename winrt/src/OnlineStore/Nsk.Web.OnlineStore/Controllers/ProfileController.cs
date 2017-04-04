using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Nsk.Web.OnlineStore.WorkerServices;

namespace Nsk.Web.OnlineStore.Controllers
{
    public class ProfileController : Controller
    {
        public IProfileControllerWorkerServices WorkerService { get; private set; }

        public ProfileController(IProfileControllerWorkerServices workerService)
        {
            Contract.Requires<ArgumentNullException>(workerService != null, "workerService");
            Contract.Ensures(this.WorkerService == workerService);

            this.WorkerService = workerService;
        }


    }
}
