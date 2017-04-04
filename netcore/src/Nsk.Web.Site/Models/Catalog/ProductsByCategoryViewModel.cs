using System.Collections.Generic;

namespace Nsk.Web.Site.Models.Catalog
{
    public class ProductsByCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Nsk.Web.Site.Models.Shared.Product> Products { get; set; }

        //public class Product
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public decimal UnitPrice { get; set; }
        //    public int SupplierId { get; set; }
        //    public string SupplierName { get; set; }
        //}
    }
}