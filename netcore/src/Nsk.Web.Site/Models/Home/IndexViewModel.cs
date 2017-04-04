using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nsk.Web.Site.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<Nsk.Web.Site.Models.Shared.Product> BestSellingProducts { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public string Query { get; set; }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        //public class Product
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string SupplierName { get; set; }
        //    public decimal? UnitPrice { get; set; }
        //}
    }
}