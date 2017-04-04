using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;

namespace Nsk.Data.EF.CodeFirst.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

    }
}
