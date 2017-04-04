using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
using SharpTestsEx.Assertions;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
	/// <summary>
	/// Summary description for CustomerFixture.
	/// </summary>
	[TestClass]
	public class CustomerTestCase
	{

        [TestMethod]
        public void CreateNewCustomer_Should_Honour_Parameters()
        {
            string id = "XYZ12";
            string companyName = "Managed Designs";
            string contactName = "Andrea Saltarello";
            Customer c = Customer.CreateNewCustomer(id, companyName, contactName);

            Assert.AreEqual<string>(id, c.Id);
            Assert.AreEqual<string>(companyName, c.Name);
            Assert.AreEqual<string>(contactName, c.ContactInfo.ContactName);
        }

        [TestMethod]
        public void CreateNewCustomer_Should_Throw_ArgumentNullException_On_Null_Customer_Id()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer(null, "Managed Designs", "Andrea Saltarello")
                )
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("id");
        }

        [TestMethod]
        public void CreateNewCustomer_Should_Throw_ArgumentNullException_On_Null_CompanyName()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer("FAKE42", null, "Andrea Saltarello")
                )
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("companyName");
        }

        [TestMethod]
        public void CreateNewCustomer_Should_Throw_ArgumentNullException_On_Null_ContactName()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer("XYZ12", "Managed Designs", null)
                )
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("contactName");
        }

        [TestMethod]
        public void CreateNewCustomer_should_throw_ArgumentException_on_blank_Customer_Id()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer(string.Empty, "Managed Designs", "Andrea Saltarello")
                )
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("id");
        }

        [TestMethod]
        public void CreateNewCustomer_should_throw_ArgumentException_on_blank_CompanyName()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer("FAKE42", " ", "Andrea Saltarello")
                )
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("companyName");
        }

        [TestMethod]
        public void CreateNewCustomer_should_throw_ArgumentException_on_blank_ContactName()
        {
            Executing.This(
                    () => Customer.CreateNewCustomer("XYZ12", "Managed Designs", " ")
                )
                .Should()
                .Throw<ArgumentException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be("contactName");
        }

        [TestMethod]
        public void New_Customers_Should_Have_Zero_Total_Income()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");

            Assert.AreEqual<decimal>(0, c.CalculateTotalIncome());
        }

        [TestMethod]
        [Ignore]
        public void Test_CalculateTotalIncome()
        {
            Customer c = Customer.CreateNewCustomer("41", "Managed Designs", "Andrea Saltarello");
            Product p = new Product() { UnitPrice = 100 };
            Order o = Order.CreateOrder(c);
            o.AddProduct(p, 0, 1);
            //c.Orders.Add(o);

            Assert.AreEqual<decimal>(100, c.CalculateTotalIncome());
        }
   
    }
}
