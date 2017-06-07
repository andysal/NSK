using Microsoft.AspNetCore.Mvc;
using Nsk.Web.Site.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nsk.Web.Site.ViewComponents
{
    public class CartItemsCounterIconViewComponent : ViewComponent
    {
        private CartControllerWorkerServices _workerServices;

        public CartItemsCounterIconViewComponent(CartControllerWorkerServices workerServices)
        {
            _workerServices = workerServices ?? throw new ArgumentNullException(nameof(workerServices)); 
        }

        public IViewComponentResult Invoke()
        {
            var itemsCount = _workerServices.GetCartItemsCount();
            return View(itemsCount);
        }
    }
}
