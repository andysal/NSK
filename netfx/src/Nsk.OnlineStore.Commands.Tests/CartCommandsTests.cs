using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using Nsk.OnlineStore.Data;

namespace Nsk.OnlineStore.Commands.Tests
{
    [TestClass]
    public class CartCommandsTests
    {
        [TestMethod]
        public void Ctor_should_throw_ArgumentNullException_on_null_cart_parameter()
        {
            Executing.This(() => new CartCommands(null))
                        .Should()
                        .Throw<ArgumentNullException>()
                        .And
                        .ValueOf
                        .ParamName
                        .Should()
                        .Be
                        .EqualTo("cart");
        }

        [TestMethod]
        public void Ctor_should_set_CurrentCart_property()
        {
            var cart = new ShoppingCart();
            var commands = new CartCommands(cart);

            Assert.AreSame(cart, commands.CurrentCart);
        }
    }
}
