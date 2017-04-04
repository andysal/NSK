
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for CustomerTest and is intended
    ///to contain all CustomerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerRegistrationTestCase
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
        public void CompanyName_Cannot_Be_Null_For_Registration()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            c.Name = null;
            Assert.IsFalse(c.IsValidForRegistration);
        }

        [TestMethod]
        public void CustomerId_Cannot_Be_Null_For_Registration()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            c.Id = null;
            Assert.IsFalse(c.IsValidForRegistration);
        }

        [TestMethod]
        public void PhoneNumber_Cannot_Be_Null_For_Registration()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            c.PhoneNumber = null;
            Assert.IsFalse(c.IsValidForRegistration);
        }
    }
}
