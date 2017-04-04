using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using Nsk.Web.OnlineStore.WorkerServices;
using Nsk.Web.OnlineStore.Models.Catalog;

namespace Nsk.Web.OnlineStore.Controllers
{
    public class CatalogController : Controller
    {
        public ICatalogControllerWorkerServices WorkerService { get; private set; }

        public CatalogController(ICatalogControllerWorkerServices svc)
        {
            Contract.Requires<ArgumentNullException>(svc!=null, "svc");
            Contract.Ensures(this.WorkerService == svc);

            this.WorkerService = svc;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id, string sort)
        {
            var model = this.WorkerService.GetProductCategoryViewModelByCategoryName(id, sort);

            return View(model);
        }

        [OutputCache(Duration=60, VaryByParam="none")]
        public ActionResult Product(int? id)
        {
            var model = this.WorkerService.GetProductViewModelByProductId(id.Value);

            return View(model);
        }

        public ActionResult Search(int? SelectedCategoryId, string SearchQuery)
        {
            int categoryId = SelectedCategoryId.HasValue ? SelectedCategoryId.Value : 0;
            var model = this.WorkerService.GetSearchPageViewModel(categoryId, SearchQuery);
            return View(model);
        }

        public ActionResult RenderAddToShoppingCartBox(AddToShoppingCartViewModel model)
        {
            if(model==null || model.Quantity==null)
            {
                model = this.WorkerService.BuildAddToShoppingCartViewModel();
            }
            return PartialView("AddToShoppingCart", model);
        }
    }
}
