using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.OnlineStore.Web.Site.Models.Catalog
{
    public class ProductsBySupplierViewModel
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
    }
}