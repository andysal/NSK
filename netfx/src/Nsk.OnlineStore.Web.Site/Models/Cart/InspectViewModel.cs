using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.OnlineStore.Web.Site.Models.Cart
{
    public class InspectViewModel
    {
        public virtual IEnumerable<CartItem> Items { set; get; }

        public class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int SupplierId { get; set; }
            public string SupplierName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public decimal TotalPrice 
        {
            get
            {
                return this.Items.Sum(i => i.UnitPrice * i.Quantity);
            }
        }
    }
}