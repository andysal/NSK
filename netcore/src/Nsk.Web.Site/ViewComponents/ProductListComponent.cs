using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nsk.Data.Model;
using Nsk.Data.ReadModel;

namespace Nsk.Web.Site.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        public IDatabase Database { get; private set; }

        public ProductListViewComponent(IDatabase database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public IViewComponentResult Invoke(IEnumerable<Nsk.Web.Site.Models.Shared.Product> products)
        {                          
            return View(products);
        }
    }
}
