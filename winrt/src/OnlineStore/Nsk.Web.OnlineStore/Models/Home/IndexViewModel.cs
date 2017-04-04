using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nsk.Web.OnlineStore.Models;

namespace Nsk.Web.OnlineStore.Models.Home
{
    public class IndexViewModel : NskPageBaseViewModel
    {
        public class ProductDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SupplierName { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal UnitsInStock { get; set; }
        }

        public IEnumerable<ProductDescriptor> RecommendedProducts { get; set; }
    }
}