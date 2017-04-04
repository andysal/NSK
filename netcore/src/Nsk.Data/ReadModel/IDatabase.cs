using System.Linq;
using Nsk.Data.Model;

namespace Nsk.Data.ReadModel
{
    public interface IDatabase
    {
        IQueryable<Category> Categories { get; }

        IQueryable<Customer> Customers { get; }

        IQueryable<Product> Products { get; }

        IQueryable<Supplier> Suppliers { get; }

        //Image GetCategoryThumbnail(int categoryId);

        ShoppingCart GetCurrentCart();
    }
}
