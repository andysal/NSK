using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nsk.Domain.Model;

namespace Nsk.Domain.Tests
{
	/// <summary>
	/// Summary description for EmployeeFixture.
	/// </summary>
	[TestClass]	
	public class EmployeeTestCase
	{
		private Employee employee;

		[TestInitialize]
		public void SetUp()
		{
			employee = new Employee();
		}

		[TestCleanup]
		public void TearDown()
		{
			employee = null;
		}

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateNewEmployee_Should_Throw_On_Null_FirstName()
        {
            Employee.CreateNewEmployee(null, "Saltarello", DateTime.Now, DateTime.Now, "Developer");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateNewEmployee_Should_Throw_On_Null_LastName()
        {
            Employee.CreateNewEmployee("Andrea", null, DateTime.Now, DateTime.Now, "Developer");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateNewEmployee_Should_Throw_On_Null_JobTitle()
        {
            Employee.CreateNewEmployee("Andrea", "Saltarello", DateTime.Now, DateTime.Now, null);
        }

        [TestMethod]
        public void CreateNewEmployee_Should_Honour_Parameters()
        {
            string firstName = "Andrea";
            string lastName = "Saltarello";
            DateTime birthDate = new DateTime(1974, 11, 13);
            DateTime hireDate = DateTime.Now;
            string jobTitle = "Developer";

            Employee e = Employee.CreateNewEmployee(firstName, lastName, birthDate, hireDate, jobTitle);

            Assert.AreEqual<string>(firstName, e.Name);
            Assert.AreEqual<string>(lastName, e.Surname);
            Assert.AreEqual<DateTime>(birthDate, e.BirthDate);
            Assert.AreEqual<DateTime>(hireDate, e.HireDate);
            Assert.AreEqual<string>(jobTitle, e.JobTitle);
        }
	}
}
