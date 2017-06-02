using Microsoft.AspNetCore.Mvc;
using Nsk.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nsk.Web.Site.ViewComponents
{
    public class LayoutSearchViewComponent : ViewComponent
    {
        private CatalogControllerWorkerServices _workerServices;

        public LayoutSearchViewComponent(CatalogControllerWorkerServices workerServices)
        {
            _workerServices = workerServices ?? throw new ArgumentNullException(nameof(workerServices));
        }
        public IViewComponentResult Invoke()
        {
            var categories = _workerServices.GetLayoutSearchViewModel();
            return View(categories);
        }
    }
}
