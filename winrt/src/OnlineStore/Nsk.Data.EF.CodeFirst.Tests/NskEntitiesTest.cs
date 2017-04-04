using ManagedDesigns.Nsk.Data.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Data.Entity;
using Nsk.Domain.Model;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;

namespace Nsk.Data.EF.CodeFirst.Tests
{


    /// <summary>
    ///This is a test class for NskEntitiesTest and is intended
    ///to contain all NskEntitiesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NskEntitiesTest
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
        ///A test for NskEntities Constructor
        ///</summary>
        [TestMethod()]
        public void CheckDB()
        {
            using (NskEntities cnt = new NskEntities())
            {
                int customersCount = cnt.Customers.Count();
                Assert.IsTrue(customersCount > 0);
                int categoriesCount = cnt.Categories.Count();
                Assert.IsTrue(categoriesCount > 0);
                int regionsCount = cnt.Regions.Count();
                Assert.IsTrue(regionsCount > 0);
                int shippersCount = cnt.Shippers.Count();
                Assert.IsTrue(shippersCount > 0);
                int suppliersCount = cnt.Suppliers.Count();
                Assert.IsTrue(suppliersCount > 0);
                int territoriesCount = cnt.Territories.Count();
                Assert.IsTrue(territoriesCount > 0);
                int productsCount = cnt.Products.Count();
                Assert.IsTrue(productsCount > 0);
                int ordersCount = cnt.Orders.Count();
                Assert.IsTrue(ordersCount > 0);
                int employeesCount = cnt.Employees.Count();
                Assert.IsTrue(employeesCount > 0);

                ///Take first record of every entity.
                Customer customer = cnt.Customers.FirstOrDefault();
                Assert.IsNotNull(customer);
                Category category = cnt.Categories.FirstOrDefault();
                Assert.IsNotNull(category);
                Region region = cnt.Regions.FirstOrDefault();
                Assert.IsNotNull(region);
                Shipper shipper = cnt.Shippers.FirstOrDefault();
                Assert.IsNotNull(shipper);
                Supplier supplier = cnt.Suppliers.FirstOrDefault();
                Assert.IsNotNull(supplier);
                Territory territory = cnt.Territories.FirstOrDefault();
                Assert.IsNotNull(territory);
                Product product = cnt.Products.Include(o => o.Category).FirstOrDefault();
                Assert.IsNotNull(product);
                Order order = cnt.Orders.Include(o => o.Customer).FirstOrDefault();
                Assert.IsNotNull(order);
                Employee employee = cnt.Employees.Include(c => c.Orders).Include(c => c.Territories).FirstOrDefault();
                Assert.IsNotNull(employee);

                #region Customer

                int rowsAffected = 0;

                Customer newCustomer = Customer.CreateNewCustomer("12346", "A Bank", "Tizio, Caio");
                newCustomer.FaxNumber = "+39 Fax Number";
                ////This code should be in Customer Constructor.
                newCustomer.MainPostalAddress = new PostalAddress();
                newCustomer.ContactInfo.ContactTitle = "Dr.";
                newCustomer.MainPostalAddress.Address = "4Th Avenue";
                newCustomer.MainPostalAddress.City = "New York";
                newCustomer.MainPostalAddress.Country = "USA";
                newCustomer.MainPostalAddress.PostalCode = "123";
                newCustomer.MainPostalAddress.Region = "Washinghton";
                newCustomer.Name = "Party Name";
                newCustomer.PhoneNumber = "+39 Phone Number";

                cnt.Customers.Add(newCustomer);

                Order newOrder = Order.CreateOrder(newCustomer);
                Product orderProduct = cnt.Products.Find(1);
                newOrder.AddProduct(orderProduct, 0, 10);
                newOrder.ShipName = "A Ship name.";
                newOrder.ShippedDate = DateTime.Now;
                newOrder.Date = DateTime.Now;
                newOrder.RequiredDate = DateTime.Now;
                newOrder.Freight = 1;
                newOrder.ShippingAddress = new PostalAddress();
                newOrder.ShippingAddress.Address = "Via Nazionale";
                newOrder.ShippingAddress.City = "Rome";
                newOrder.ShippingAddress.Country = "Italy";
                newOrder.ShippingAddress.PostalCode = "00100";
                newOrder.ShippingAddress.Region = "Lazio";

                cnt.Orders.Add(newOrder);

                try
                {
                    rowsAffected = cnt.SaveChanges();
                    Assert.IsTrue(rowsAffected > 0);

                    cnt.Customers.Remove(newCustomer);
                    cnt.Orders.Remove(newOrder);

                    rowsAffected = cnt.SaveChanges();
                    Assert.IsTrue(rowsAffected > 0);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult dbValidationResult in ex.EntityValidationErrors)
                    {
                        if (!dbValidationResult.IsValid)
                        {
                            foreach (DbValidationError dbValidationError in dbValidationResult.ValidationErrors)
                            {
                                Assert.Inconclusive("Error in {0}: {1}", dbValidationError.PropertyName, dbValidationError.ErrorMessage);
                            }
                        }
                    }
                }

                #endregion

                #region Category

                Category newCategory = new Category();
                newCategory.Name = "Horror";
                newCategory.Description = "Horror's movies.";

                cnt.Categories.Add(newCategory);
                rowsAffected = cnt.SaveChanges();
                Assert.IsTrue(rowsAffected > 0);

                cnt.Categories.Remove(newCategory);
                rowsAffected = cnt.SaveChanges();
                Assert.IsTrue(rowsAffected > 0);

                #endregion

                ////TODO
                #region Shipper

                Shipper newShipper = new Shipper();
                newShipper.CompanyName = "A ICT Company";
                newShipper.Phone = "123";
                cnt.Shippers.Add(newShipper);
                rowsAffected = cnt.SaveChanges();
                Assert.IsTrue(rowsAffected > 0);

                #endregion

                ////TODO
                #region Supplier
                #endregion

                ////TODO
                #region Territory
                #endregion

                ////TODO
                #region Territory
                #endregion

                ////TODO
                #region Product
                #endregion

                ////TODO
                #region Order


                #endregion

                ////TODO
                #region Employee

                Employee boss = Employee.CreateNewEmployee("Mario", "Rossi", new DateTime(1980, 10, 1), new DateTime(1999, 1, 1), "Project Manager");
                boss.Extension = ".jpg";
                boss.HomePhone = "+39 123";
                boss.MainPostalAddress = new PostalAddress();
                boss.MainPostalAddress.Address = "Address";
                boss.MainPostalAddress.City = "Rome";
                boss.MainPostalAddress.Country = "Italy";
                boss.MainPostalAddress.PostalCode = "00100";
                boss.MainPostalAddress.Region = "Lazio";
                boss.Notes = "Notes";
                boss.PhotoPath = @"C:\";
                boss.TitleOfCourtesy = "Dott";

                cnt.Employees.Add(boss);

                try
                {
                    rowsAffected = cnt.SaveChanges();
                    Assert.IsTrue(employeesCount > 0);

                    Employee programmer = Employee.CreateNewEmployee("Giulio", "Bianchi", new DateTime(1976, 9, 2), new DateTime(1999, 2, 3), "Programmer");
                    programmer.Extension = ".jpg";
                    programmer.HomePhone = "+39 123";
                    programmer.MainPostalAddress = new PostalAddress();
                    programmer.MainPostalAddress.Address = "Address";
                    programmer.MainPostalAddress.City = "Rome";
                    programmer.MainPostalAddress.Country = "Italy";
                    programmer.MainPostalAddress.PostalCode = "00100";
                    programmer.MainPostalAddress.Region = "Lazio";
                    programmer.Notes = "Notes";
                    programmer.PhotoPath = @"C:\";
                    programmer.TitleOfCourtesy = "Dott";

                    programmer.Reports = new System.Collections.Generic.List<Employee>();
                    programmer.Manager = boss; ////OK.

                    //programmer.Reports.Add(boss);

                    cnt.Employees.Add(programmer);
                    rowsAffected = cnt.SaveChanges();
                    Assert.IsTrue(rowsAffected > 0);

                    cnt.Employees.Remove(boss);
                    cnt.Employees.Remove(programmer);
                    rowsAffected = cnt.SaveChanges();
                    Assert.IsTrue(rowsAffected > 0);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult dbValidationResult in ex.EntityValidationErrors)
                    {
                        if (!dbValidationResult.IsValid)
                        {
                            foreach (DbValidationError dbValidationError in dbValidationResult.ValidationErrors)
                            {
                                Assert.Inconclusive("Error in {0}: {1}", dbValidationError.PropertyName, dbValidationError.ErrorMessage);
                            }
                        }
                    }
                }

                #endregion
            }
        }
    }
}
