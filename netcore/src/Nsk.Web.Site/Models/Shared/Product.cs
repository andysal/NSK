using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nsk.Web.Site.Models.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
