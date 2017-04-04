using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.Web.OnlineStore.Models.Catalog
{
    public class SearchViewModel : NskPageBaseViewModel
    {
        public IEnumerable<ProductCategoryDescriptor> Categories { get; set; }
        public IEnumerable<ProductInfo> Products { get; set; }

        public class ProductCategoryDescriptor
        {
            public string Name { get; set; }
            public int ProductCount { get; set; }
        }

        public class ProductInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal UnitsInStock { get; set; }
        }
    }
}