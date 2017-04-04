using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moq;
using SharpTestsEx;
using Nsk.Domain.ReadModel;
using Nsk.Domain.Services;
using Nsk.Web.OnlineStore.WorkerServices.Impl;

namespace Nsk.Web.OnlineStore.Tests
{
    
    
    /// <summary>
    ///This is a test class for CatalogControllerWorkerServicesTest and is intended
    ///to contain all CatalogControllerWorkerServicesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CatalogControllerWorkerServicesTest
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
        public void Constructor_should_Throw_on_null_readModelFacade_parameter()
        {
            var mock = new Mock<ICatalogServices>().Object;
            Executing.This(
                    () => new CatalogControllerWorkerServices(null, mock)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("readModelFacade");
        }

        [TestMethod()]
        public void Constructor_should_Throw_on_null_catalogServices_parameter()
        {
            var mock = new Mock<IReadModelFacade>().Object;
            Executing.This(
                    () => new CatalogControllerWorkerServices(mock, null)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("catalogServices");
        }    
    }
}
