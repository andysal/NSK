using System;
using System.Collections.Generic;
using System.Text;
using Nsk.Domain;

namespace Nsk.Domain.Model
{
    public class Product : IAggregateRoot
    {
        public virtual int Id { get; set; }

        public virtual Category Category { get; set; }

        public virtual bool IsDiscontinued { get; set; }

        public virtual string Name { get; set; }

        public virtual string QuantityPerUnit { get; set; }

        public virtual short ReorderLevel { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual short UnitsInStock { get; set; }

        public virtual short UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets the order items
        /// </summary>
        protected virtual ICollection<OrderItem> OrderItems { get; set; }

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
