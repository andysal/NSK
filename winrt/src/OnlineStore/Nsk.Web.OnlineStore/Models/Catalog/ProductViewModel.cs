using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.Web.OnlineStore.Models.Catalog
{
    public class ProductViewModel : NskPageBaseViewModel
    {
        public class ProductDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
            public string QuantityPerUnit { get; set; }
        }

        public class RelatedProductDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
        }

        public ProductDescriptor ProductDetail { get; set; }
        public IEnumerable<RelatedProductDescriptor> RelatedProducts { get; set; }
    }
}