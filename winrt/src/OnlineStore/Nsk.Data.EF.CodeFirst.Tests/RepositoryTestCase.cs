
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Nsk.Domain;
using Nsk.Domain.Repositories;
using Nsk.Data.EF.CodeFirst.Repositories;

namespace Nsk.Data.EF.CodeFirst.Tests
{
    
    
    /// <summary>
    ///This is a test class for RepositoryTest and is intended
    ///to contain all RepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositoryTest
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
        /////A test for Repository`1 Constructor
        /////</summary>
        //[ExpectedException(typeof(ArgumentNullException))]
        //[TestMethod]
        //public void Repository_Constructor_Should_Throw_On_Null_Context()
        //{
        //    NorthwindContext context = null;
        //    Repository<IAggregateRoot> target = new Repository<IAggregateRoot>(context);
        //}


    }
}
