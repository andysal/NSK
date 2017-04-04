using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nsk.Data;
using Nsk.Data.Model;

namespace Nsk.Commands
{
    public class CartCommands
    {
        public ShoppingCart CurrentCart { get; private set; }


        /// <summary>
        /// Creates a new instance
        /// </summary>
        public CartCommands()
        {
            CurrentCart = ShoppingCart.GetCart();
        }

        public CartCommands(ShoppingCart cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));
            CurrentCart = cart;
        }

        /// <summary>
        /// Adds the specified product to the cart
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="quantity">The product's quantity to be added to the cart</param>
        /// <exception cref="ProductIsNotForSaleException">Thrown if the product is not for sale</exception>
        public void AddProductToCart(int productId, int quantity)
        {
            using (var ctx = new NorthwindContext())
            {
                var product = ctx.Products
                    .Where(p => p.Id == productId)
                    .SingleOrDefault();
                if(product == null || product.IsDiscontinued)
                {
                    throw new ProductIsNotForSaleException();
                }
                CurrentCart.AddProduct(product.Id, quantity, product.UnitPrice.Value);
            }
        }

        /// <summary>
        /// Removes the specified product from the current cart
        /// </summary>
        /// <param name="productId">The id of the product to be removed from the current cart</param>
        public void RemoveProductFromCart(int productId)
        {
            CurrentCart.RemoveProduct(productId);
        }

        /// <summary>
        /// Updates the quantity of the specified prodct
        /// </summary>
        /// <param name="productId">The id of the product whose quantity is to be modified</param>
        /// <param name="quantity">The quantity</param>
        public void UpdateProductQuantity(int productId, int quantity)
        {
            CurrentCart.UpdateProductQuantity(productId, quantity);
        }
    }
}
