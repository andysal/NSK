﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nsk.Web.Site.Models.Catalog
{
    public class SearchViewModel: BaseSearchViewModel
    {

        public IEnumerable<Product> Products { get; set; }

        public int? MaxUnitPrice { get; set; }

        public int? MinUnitPrice { get; set; }



        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public string SupplierName { get; set; }
            public decimal? UnitPrice { get; set; }
        }
    }
}