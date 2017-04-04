using Nsk.Web.OnlineStore.Models.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using SharpTestsEx;

namespace Nsk.Web.OnlineStore.Models.Home.Tests
{
    
    
    /// <summary>
    ///This is a test class for RegisterViewModelTest and is intended
    ///to contain all RegisterViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegisterViewModelTest
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


        ///// <summary>
        /////A test for System.ComponentModel.DataAnnotations.IValidatableObject.Validate
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\User Data\\andrea.saltarello\\tfs\\trunk\\NSK\\src\\Nsk.Web.OnlineStore", "/")]
        //[UrlToTest("http://localhost:50981/")]
        //[DeploymentItem("Nsk.Web.OnlineStore.dll")]
        //public void ValidateTest()
        //{
        //    IValidatableObject target = new RegisterViewModel(); // TODO: Initialize to an appropriate value
        //    ValidationContext validationContext = null; // TODO: Initialize to an appropriate value
        //    IEnumerable<ValidationResult> expected = null; // TODO: Initialize to an appropriate value
        //    IEnumerable<ValidationResult> actual;
        //    actual = target.Validate(validationContext);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        [TestMethod]
        public void Validate_Should_Throw_on_Null_ValidationContext()
        {
            IValidatableObject target = new RegisterViewModel();
            Executing.This(
                    () => target.Validate(null)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("validationContext");
        }

        [Ignore]
        [TestMethod]
        public void Validate_Should_Not_Return_a_Null_Value()
        {
            IValidatableObject target = new RegisterViewModel();
            ValidationContext validationContext = new ValidationContext(null, null, null);
            Assert.IsNotNull(target.Validate(validationContext));
        }
    }
}
