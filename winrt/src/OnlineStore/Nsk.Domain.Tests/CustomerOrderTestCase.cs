
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for CustomerTest and is intended
    ///to contain all CustomerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerOrderTestCase
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

        [TestMethod]
        public void Customer_Having_Null_Address_Cannot_Make_Orders()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            c.MainPostalAddress = null;
            Assert.IsFalse(c.CanPlaceOrders);
        }

        [TestMethod]
        public void Customer_Not_ValidForRegistration_Cannot_Make_Orders()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            c.Name = null;
            Assert.IsFalse(c.CanPlaceOrders);
        }

        [TestMethod]
        public void Customer_Should_Be_ValidForRegistration_And_Have_An_Address_To_Make_Orders()
        {
            Customer c = Customer.CreateNewCustomer("XYZ12", "Managed Designs", "Andrea Saltarello");
            c.MainPostalAddress = new PostalAddress();
            Assert.IsTrue(c.CanPlaceOrders);
        }
    }
}
