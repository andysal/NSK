using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using Nsk.Data.EF.Poco.Model;
using System.Data.Entity.Core.Objects;

namespace Nsk.Data.EF.Poco.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected override void AddObject(Order item)
        {
            this.ActiveContext.Orders.AddObject(item);
        }

        protected override void DeleteObject(Order item)
        {
            this.ActiveContext.Orders.DeleteObject(item);
        }

        protected override ObjectQuery<Order> GetObjectQuery()
        {
            return this.ActiveContext.Orders;
        }
    }
}
