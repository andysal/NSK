using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Nsk.Metro.Services.Models.Catalog
{
    public class ProductCategoryInfo
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
