using System;
using System.Collections.Generic;

namespace Nsk.Data.Model
{
    public partial class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
