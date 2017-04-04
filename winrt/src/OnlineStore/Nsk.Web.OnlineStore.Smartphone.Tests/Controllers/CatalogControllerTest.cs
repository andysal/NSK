using Nsk.Web.OnlineStore.Smartphone.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Nsk.Web.OnlineStore.Smartphone.WorkerServices.Catalog;
using SharpTestsEx;

namespace Nsk.Web.OnlineStore.Smartphone.Tests
{
    
    
    /// <summary>
    ///This is a test class for CatalogControllerTest and is intended
    ///to contain all CatalogControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CatalogControllerTest
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
        public void CatalogController_Constructor_should_Throw_on_null_WorkerService()
        {
            ICatalogControllerWorkerServices svc = null;
            Executing.This(
                    () => new CatalogController(svc)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("workerService");
        }
    }
}
