using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("Order Details");       

            this.HasRequired(o => o.Order);

            this.HasRequired(o => o.Product);

            this.FixedOrderItemHasKey<OrderItem>("OrderId", "ProductId");
        }
    }
}
