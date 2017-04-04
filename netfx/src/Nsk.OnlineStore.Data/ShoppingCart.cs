using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nsk.OnlineStore.Data
{
    public class ShoppingCart
    {
        public virtual IEnumerable<CartItem> Items { private set; get; }

        public class CartItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }

        }

        internal ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public void AddProduct(int productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Product quantoty must be higher than zero.", "quantity");
            }
            var item = Items.Where(i => i.ProductId == productId)
                            .SingleOrDefault();
            if(item!=null)
            {
                UpdateProductQuantity(productId, item.Quantity += quantity);
            }
            else
            {
                item = new CartItem()
                                {
                                    ProductId = productId,
                                    Quantity = quantity,
                                    UnitPrice = unitPrice
                                };
                (Items as List<CartItem>).Add(item);
            }
        }

        public void RemoveProduct(int productId)
        {
            var item = Items.Where(i => i.ProductId == productId)
                            .SingleOrDefault();
            if (item == null)
            {
                throw new ArgumentException("The cart does not cointain the specified product.", "productId");
            }
            else
            {
                (Items as List<CartItem>).Remove(item);
            }
        }

        public void UpdateProductQuantity(int productId, int quantity)
        {
            if(quantity<=0)
            {
                throw new ArgumentException("Product quantoty must be higher than zero.", "quantity");
            }
            var item = Items.Where(i => i.ProductId == productId)
                            .SingleOrDefault();
            if (item == null)
            {
                throw new ArgumentException("The cart does not cointain the specified product.", "productId");
            }
            else
            {
                item.Quantity = quantity;
            }
        }

        internal static ShoppingCart GetCart()
        {
            var session = HttpContext.Current.Session;
            if(session["cart"]==null)
            {
                session["cart"] = new ShoppingCart();
            }
            return (ShoppingCart) session["cart"];
        }
    }
}
