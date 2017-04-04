
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for ContactInfoTest and is intended
    ///to contain all ContactInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContactInfoTest
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
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToString_Should_Returns_Both_Name_And_Title()
        {
            string contactName = "Andrea Saltarello";
            string contactTitle = "Mr.";
            
            ContactInfo target = new ContactInfo() { ContactName = contactName, ContactTitle = contactTitle };
            string expected = string.Format("{0}, {1}", contactName, contactTitle); 
            string actual = target.ToString();
            
            Assert.AreEqual(expected, actual);
        }
    }
}
