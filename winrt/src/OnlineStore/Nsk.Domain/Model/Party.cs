using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsk.Domain.Model
{
    /// <summary>
    /// Represents a party, which is a person or an organization
    /// </summary>
    public abstract class Party
    {
        /// <summary>
        /// Gets or sets the name of the party
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the address informations
        /// </summary>
        public virtual PostalAddress MainPostalAddress { get; set; }
    }
}
