using System.Collections.Generic;
using System.ComponentModel;

namespace Nsk.Web.Site.Models.Catalog
{
    public class ProductDetailViewModel
    {
        public IEnumerable<RelatedProduct> RelatedProducts { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [DisplayName("Quantity per unit:")]
        public string QuantityPerUnit { get; set; }

        [DisplayName("Price:")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Units in stock:")]
        public short UnitsInStock { get; set; }

        public class RelatedProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}