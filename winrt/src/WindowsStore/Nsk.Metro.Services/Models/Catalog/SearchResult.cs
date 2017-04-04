using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.Metro.Services.Models.Catalog
{
    public class SearchResult
    {
        public IEnumerable<SearchResult.ProductCategoryInfo> Categories { get; set; }

        public IEnumerable<SearchResult.ProductInfo> Products { get; set; }

        public class ProductInfo
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public decimal? UnitPrice { get; set; }
        }

        public class ProductCategoryInfo
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}