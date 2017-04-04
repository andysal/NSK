using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.Metro.Services.Models.Catalog
{
    public class ProductInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}