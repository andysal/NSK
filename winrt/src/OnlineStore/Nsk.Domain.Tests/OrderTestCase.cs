using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SharpTestsEx;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for OrderTestCase and is intended
    ///to contain all OrderTestCase Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderTestCase
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void CreateOrder_Should_Associate_The_Customer_To_The_Order()
        {
            Customer customer = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            Order expected = Order.CreateOrder(customer);
            Assert.AreSame(expected.Customer, customer);
        }

        [TestMethod()]
        public void CreateOrder_Should_Throw_On_Null_Customer()
        {
            Executing
                .This(() => Order.CreateOrder(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("customer");
        }

        [TestMethod()]
        public void New_Order_Has_Price_Zero()
        {
            Customer c = Customer.CreateNewCustomer("42", "Managed Designs", "Andrea Saltarello");
            Order target = Order.CreateOrder(c);
            Assert.AreEqual(0, target.CalculatePrice());
        }

        [TestMethod()]
        public void Adding_an_already_existing_Product_to_an_order_should_throw_ArgumentException()
        {
            var p = new Product() {Id = 42};
            Customer c = Customer.CreateNewCustomer("MDS42", "Managed Designs", "Andrea Saltarello");
            Order o = Order.CreateOrder(c);
            o.AddProduct(p, 1, 1);

            Executing.This(
                     () => o.AddProduct(p, 2, 2)
                 )
                 .Should()
                 .Throw<ArgumentException>()
                 .And
                 .ValueOf
                 .ParamName
                 .Should()
                 .Be("product");
        }

        [TestMethod()]
        public void Adding_a_Product_with_quantity_Zero_should_throw_ArgumentException()
        {
            Product p = new Product() { Id = 42 };
            Customer c = Customer.CreateNewCustomer("MDS42", "Managed Designs", "Andrea Saltarello");
            Order o = Order.CreateOrder(c);

            Executing.This(
                     () => o.AddProduct(p, 2, 0)
                 )
                 .Should()
                 .Throw<ArgumentException>()
                 .And
                 .ValueOf
                 .ParamName
                 .Should()
                 .Be("quantity");
        }

        [TestMethod()]
        public void Adding_a_Product_with_quantity_lesser_than_Zero_should_throw_ArgumentException()
        {
            Product p = new Product() { Id = 42 };
            Customer c = Customer.CreateNewCustomer("MDS42", "Managed Designs", "Andrea Saltarello");
            Order o = Order.CreateOrder(c);

            Executing.This(
                     () => o.AddProduct(p, 2, -1)
                 )
                 .Should()
                 .Throw<ArgumentException>()
                 .And
                 .ValueOf
                 .ParamName
                 .Should()
                 .Be("quantity");
        }
    }
}
