
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpTestsEx;
using SharpTestsEx.Assertions;
using Nsk.Data.Hibernate;

namespace Nsk.Data.Hibernate.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProductRepositoryTest and is intended
    ///to contain all ProductRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductRepositoryTest
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
        ///A test for ProductRepository Constructor
        ///</summary>
        [TestMethod()]
        public void ProductRepository_Constructor_Should_Throw_On_Null_SessionManagementStrategy()
        {
            Executing.This(
                    () => new ProductRepository(null)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("sessionManagementStrategy");
        }
    }
}
