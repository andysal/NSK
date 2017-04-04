using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using SharpTestsEx;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using Nsk.Domain.Services.Impl;

namespace Nsk.Domain.Services.Test
{
    
    
    /// <summary>
    ///This is a test class for MarketingServicesTest and is intended
    ///to contain all MarketingServicesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MarketingServicesTest
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

        #region TEST: tests
        [TestMethod]
        public void MarketingServices_Ctor_should_Throw_ArgumentNullException_on_Null_CustomerRepository()
        {
            Executing.This(() => new MarketingServices(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("customerRepository");
        }
        #endregion

        #region TEST: calculation of suggested discount rate

        /// <summary>
        ///A test for CalculateSuggestedDiscountRate
        ///</summary>
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod()]
        public void CalculateSuggestedDiscountRate_Should_Throw_ArgumentNullException_On_Null_Customer_Id()
        {
            var repo = new Mock<ICustomerRepository>();
            MarketingServices target = new MarketingServices(repo.Object);
            target.CalculateSuggestedDiscountRate(null);
        }

        /// <summary>
        ///A test for CalculateSuggestedDiscountRate
        ///</summary>
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void CalculateSuggestedDiscountRate_Should_Throw_ArgumentException_On_Blank_Customer_Id()
        {
            var repo = new Mock<ICustomerRepository>();
            MarketingServices target = new MarketingServices(repo.Object);
            target.CalculateSuggestedDiscountRate(string.Empty);
        }

       
        private static Mock<ICustomerRepository> BuildCustomerRepository(decimal generatedIncome, string customerId)
        {
            var custMockBuilder = new Mock<Customer>();
            custMockBuilder.Setup(c => c.CalculateTotalIncome()).Returns(generatedIncome);
            var repoMockBuilder = new Mock<ICustomerRepository>();
            repoMockBuilder.Setup(r => r.FindById(customerId)).Returns(custMockBuilder.Object);
            return repoMockBuilder;
        }

        [TestMethod]
        public void Test_Calculation_Of_Suggested_Discount_Rate_For_Customers_With_Total_Income_Of_Less_Than_5000_Dollars()
        {
            decimal generatedIncome = 3500;
            string customerId = "FAKE1";
            var repoMockBuilder = BuildCustomerRepository(generatedIncome, customerId);

            MarketingServices svc = new MarketingServices(repoMockBuilder.Object);
            Assert.AreEqual<decimal>(0.035M, svc.CalculateSuggestedDiscountRate(customerId));
        }

        [TestMethod]
        public void Test_Calculation_Of_Suggested_Discount_Rate_For_Customers_With_Total_Income_Of_5000_Dollars_Or_More()
        {
            decimal generatedIncome = 6000;
            string customerId = "FAKE1";
            var repoMockBuilder = BuildCustomerRepository(generatedIncome, customerId);

            MarketingServices svc = new MarketingServices(repoMockBuilder.Object);
            Assert.AreEqual<decimal>(0.06M, svc.CalculateSuggestedDiscountRate(customerId));
        }

        [TestMethod]
        public void Suggested_Discount_Rate_Should_Be_Zero_For_New_Customers()
        {
            string customerId = "FAKE1";
            Customer c = Customer.CreateNewCustomer(customerId, "Managed Designs", "Andrea Saltarello");
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(r => r.FindById(customerId)).Returns(c);

            MarketingServices target = new MarketingServices(repo.Object);
            Assert.AreEqual<decimal>(0, target.CalculateSuggestedDiscountRate(customerId));
        }
        #endregion
    }
}
