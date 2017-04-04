using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nsk.Data.Model;

namespace Nsk.Data.ReadModel
{
    public static class OrderExtensions
    {
        public static IQueryable<Order> Current(this IQueryable<Order> orders)
        {
            return orders.Where(o => o.ShippedDate == null);
        }
    }
}
