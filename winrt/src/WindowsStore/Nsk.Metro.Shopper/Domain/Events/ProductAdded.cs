using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Nsk.Metro.Shopper.Domain.Events
{
    public class ProductAdded
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
