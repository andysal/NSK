// CREATED BY andysal on 05/09/2005
// UPDATED BY andysal on 25/06/2008
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Nsk.Domain.Model
{
    /// <summary>
    /// Represents a supplier
    /// </summary>
    public class Supplier : Organization
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [StringLengthValidator(24)]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number
        /// </summary>
        [StringLengthValidator(24)]
        public virtual string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the home page
        /// </summary>
        public virtual string HomePage { get; set; }

        /// <summary>
        /// Gets or sets the contact info
        /// </summary>
        public virtual ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// Gets the products managed by the Supplier
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
