using System.Collections.Generic;

namespace Nsk.Web.Site.Models.Home
{
    public class SiteMapViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}