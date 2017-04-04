using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.ReadModel;

namespace Nsk.Data.ReadModel.EF.CodeFirst.Mapping
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
