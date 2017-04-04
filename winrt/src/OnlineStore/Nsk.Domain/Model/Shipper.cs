// CREATED BY andysal on 05/09/2005
// UPDATED BY andysal on 25/06/2008
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Nsk.Domain.Model
{
    /// <summary>
    /// Represents a shipper
    /// </summary>
    public class Shipper
    {
        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        [StringLengthValidator(40)] 
        [NotNullValidator()]
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [StringLengthValidator(24)]
        public virtual string Phone { get; set; }

        /// <summary>
        /// Gets the orders managed by the shipper
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
