using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Nsk.Domain.ReadModel
{
    public interface IReadModelFacade
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Employee> Employees { get; }
        IQueryable<Order> Orders { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Region> Regions { get; }
        IQueryable<Shipper> Shippers { get; }
        IQueryable<Supplier> Suppliers { get; }
        IQueryable<Territory> Territories { get; }

        Image GetThumbnailByCategory(int categoryId);
    }
}
