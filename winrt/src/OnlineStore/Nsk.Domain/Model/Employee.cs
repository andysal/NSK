using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Nsk.Domain;

namespace Nsk.Domain.Model
{
    /// <summary>
    /// Defines an entity representing an employee
    /// </summary>
    public class Employee : Person, IAggregateRoot
	{
        private ICollection<Territory> territories = new List<Territory>();

        public static Employee CreateNewEmployee(string firstName, string lastName, DateTime birthDate, DateTime hireDate, string jobTitle)
        {
            Contract.Requires<ArgumentNullException>(firstName != null, "firstName");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(firstName), "firstName");
            Contract.Requires<ArgumentNullException>(lastName != null, "lastName");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(lastName), "lastName");
            Contract.Requires<ArgumentNullException>(jobTitle != null, "jobTitle");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(jobTitle), "jobTitle");

            var e = new Employee();
            e.Name = firstName;
            e.Surname = lastName;
            e.BirthDate = birthDate;
            e.HireDate = hireDate;
            e.JobTitle = jobTitle;
            return e;
        }

        /// <summary>
        /// Gets or sets the id of the employee
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the job title
        /// </summary>
        public virtual string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the title of courtesy
        /// </summary>
        public virtual string TitleOfCourtesy { get; set; }

        /// <summary>
        /// Gets or sets the Hire Date
        /// </summary>
        public virtual DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets the Home Phone
        /// </summary>
        public virtual string HomePhone { get; set; }

        /// <summary>
        /// Gets or sets the Extension
        /// </summary>
        public virtual string Extension { get; set; }

        /// <summary>
        /// Gets or sets the Notes
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Photo path
        /// </summary>
        public virtual string PhotoPath { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }

        public virtual ICollection<Employee> Reports { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the Manager
        /// </summary>
        public virtual Employee Manager {get; set;}

        /// <summary>
        /// Gets wether the current aggregate can be saved
        /// </summary>
        bool IAggregateRoot.CanBeSaved
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets wether the current aggregate can be deleted
        /// </summary>
        bool IAggregateRoot.CanBeDeleted
        {
            get
            {
                return true;
            }
        }
	}
}
