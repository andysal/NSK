using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nsk.Web.Mvc;

namespace Nsk.Web.OnlineStore.Smartphone.Models.Catalog
{
    public class ProductViewModel : HtmlPageViewModel
    {
        public class ProductDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
            public string QuantityPerUnit { get; set; }
        }

        public ProductDescriptor ProductDetail { get; set; }
    }
}