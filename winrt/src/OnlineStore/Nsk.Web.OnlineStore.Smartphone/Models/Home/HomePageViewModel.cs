using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nsk.Web.Mvc;
using Nsk.Domain.Model;

namespace Nsk.Web.OnlineStore.Smartphone.Models.Home
{
    public class IndexViewModel : HtmlPageViewModel
    {
        public class ProductDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SupplierName { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public ProductDescriptor RecommendedProduct { get; set; }
    }
}