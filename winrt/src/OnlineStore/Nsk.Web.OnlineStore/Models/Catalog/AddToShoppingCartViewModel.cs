using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nsk.Web.OnlineStore.Models.Catalog
{
    public class AddToShoppingCartViewModel : NskPageBaseViewModel
    {
        public SelectList Quantity { get; set; }
        public IEnumerable<SelectListItem> SelectableQuantities { get; set; }  
    }
}