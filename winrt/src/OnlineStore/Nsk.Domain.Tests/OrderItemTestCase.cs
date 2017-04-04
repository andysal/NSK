
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for OrderItemTestCase and is intended
    ///to contain all OrderItemTestCase Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderItemTestCase
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

        /// <summary>
        ///A test for GetPrice
        ///</summary>
        [TestMethod()]
        public void GetPrice_Returns_The_Correct_Price()
        {
            OrderItem target = new OrderItem();
            target.Discount = 0.1F;
            target.UnitPrice = 100;
            target.Quantity = 2;
            decimal actual = target.GetPrice();
            Assert.AreEqual(180, actual);
        }

        /// <summary>
        ///A test for GetBasePrice
        ///</summary>
        [TestMethod()]
        public void GetBasePrice_Returns_The_Correct_Price()
        {
            OrderItem target = new OrderItem();
            target.UnitPrice = 101;
            target.Quantity = 2;
            decimal actual = target.GetBasePrice();
            Assert.AreEqual(202, actual);
        }
    }
}
