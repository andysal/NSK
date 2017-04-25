using Nsk.Commands;
using Nsk.Data.ReadModel;
using Nsk.Web.Site.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nsk.Web.Site.WorkerServices
{
    public class CartControllerWorkerServices
    {
        public IDatabase Database { get; private set; }
        public CartCommands Commands { get; private set; }

        public CartControllerWorkerServices(IDatabase database, CartCommands commands)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public void PostAddProduct(int productId, int quantity)
        {
            Commands.AddProductToCart(productId, quantity);
        }

        public void GetRemoveProduct(int productId)
        {
            Commands.RemoveProductFromCart(productId);
        }

        public void GetUpdateProduct(int productId, int quantity)
        {
            Commands.UpdateProductQuantity(productId, quantity);
        }

        public InspectViewModel GetInspectViewModel()
        {
            var cart = Database.GetCurrentCart();
            var productsIds = (from i in cart.Items
                              select i.ProductId).ToList();
            var model = new InspectViewModel();
            model.Items = (from p in Database.Products
                          where productsIds.Contains(p.Id)
                          orderby p.Name
                          select new InspectViewModel.CartItem
                          {
                               ProductId = p.Id,
                               ProductName = p.Name,
                               SupplierId = p.SupplierId.Value,
                               SupplierName = p.Supplier.CompanyName
                          }).ToList();
            foreach(var item in model.Items)
            {
                var i = cart.Items.Where(x => x.ProductId == item.ProductId).Single();
                item.Quantity = i.Quantity;
                item.UnitPrice = i.UnitPrice;
            }
            return model;
        }

        public CheckoutViewModel GetCheckoutViewModel()
        {
            var cart = Database.GetCurrentCart();
            var productsIds = (from i in cart.Items
                               select i.ProductId).ToList();
            var model = new CheckoutViewModel();
            model.Items = (from p in Database.Products
                           where productsIds.Contains(p.Id)
                           orderby p.Name
                           select new CheckoutViewModel.CartItem
                           {
                               ProductId = p.Id,
                               ProductName = p.Name,
                               SupplierId = p.SupplierId.Value,
                               SupplierName = p.Supplier.CompanyName
                           }).ToList();
            foreach (var item in model.Items)
            {
                var i = cart.Items.Where(x => x.ProductId == item.ProductId).Single();
                item.Quantity = i.Quantity;
                item.UnitPrice = i.UnitPrice;
            }
            return model;
        }
    }
}