using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.OnlineStore.Data.ReadModel
{
    public interface IDatabase
    {
        IQueryable<Category> Categories { get; }

        IQueryable<Customer> Customers { get; }

        IQueryable<Product> Products { get; }

        IQueryable<Supplier> Suppliers { get; }

        Image GetCategoryThumbnail(int categoryId);

        ShoppingCart GetCurrentCart();
    }
}
