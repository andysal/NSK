using Nsk.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Practices.Unity;
using SharpTestsEx;
using Moq;

namespace ManagedDesigns.Nsk.Web.Tests
{
    
    
    /// <summary>
    ///This is a test class for UnityControllerFactoryTest and is intended
    ///to contain all UnityControllerFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnityControllerFactoryTest
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
        public void UnityControllerFactory_Constructor_should_Throw_on_null_Container()
        {
            Executing.This(
                    () => new UnityControllerFactory(null)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("container");
        }

        [TestMethod()]
        public void GetControllerInstance_should_Throw_on_null_RequestContext()
        {
            IUnityContainer container = new Mock<IUnityContainer>().Object;
            UnityControllerFactory factory = new UnityControllerFactory(container);
            Executing.This(
                    () => factory.CreateController(null, "fake")
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("requestContext");
        }
    }
}
