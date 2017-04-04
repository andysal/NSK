using System;
using System.Collections.Generic;

namespace Nsk.Data.Model
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Reports { get; set; }
    }
}
