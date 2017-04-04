using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Nsk.OnlineStore.Data.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void AddProduct_should_throw_ArgumentException_on_product_quantity_of_zero_or_less()
        {
            var sut = new ShoppingCart();
            Executing.This(() => sut.AddProduct(42, 0, 101))
                        .Should()
                        .Throw<ArgumentException>()
                        .And
                        .ValueOf
                        .ParamName
                        .Should()
                        .Be
                        .EqualTo("quantity");
        }

        [TestMethod]
        public void AddProduct_should_create_an_item()
        {
            var productId = 42;
            var quantity = 101;
            var unitPrice = 15M;
            var sut = new ShoppingCart();
            sut.AddProduct(productId, quantity, unitPrice);

            Assert.AreEqual<int>(1, sut.Items.Count());

            var item = sut.Items.First();
            Assert.AreEqual<int>(productId, item.ProductId);
            Assert.AreEqual<int>(quantity, item.Quantity);
            Assert.AreEqual<decimal>(unitPrice, item.UnitPrice);
        }

        [TestMethod]
        public void UpdateProductQuantity_should_throw_ArgumentException_on_product_quantity_of_zero_or_less()
        {
            var productId = 42;
            var quantity = 101;
            var unitPrice = 15M;
            var sut = new ShoppingCart();

            sut.AddProduct(productId, quantity, unitPrice);

            Executing.This(() => sut.UpdateProductQuantity(productId, 0))
                        .Should()
                        .Throw<ArgumentException>()
                        .And
                        .ValueOf
                        .ParamName
                        .Should()
                        .Be
                        .EqualTo("quantity");
        }

        [TestMethod]
        public void UpdateProductQuantity_should_update_product_quantity_accordingly()
        {
            var productId = 42;
            var quantity = 101;
            var updatedQuantity = 42;
            var unitPrice = 15M;
            var sut = new ShoppingCart();
            
            sut.AddProduct(productId, quantity, unitPrice);
            sut.UpdateProductQuantity(productId, updatedQuantity);

            var item = sut.Items.First();
            Assert.AreEqual<int>(updatedQuantity, item.Quantity);
        }
    }
}
