using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.OnlineStore.Data.ReadModel
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> ByCategory(this IQueryable<Product> products, int categoryId)
        {
            return products.Where(p => p.CategoryID == categoryId);
        }

        public static IQueryable<Product> ByCategory(this IQueryable<Product> products, string categoryName)
        {
            return products.Where(p => p.Category.Name == categoryName);
        }

        public static IQueryable<Product> BySupplier(this IQueryable<Product> products, int supplierId)
        {
            return products.Where(p => p.SupplierID == supplierId);
        }

        public static IQueryable<Product> ForSale(this IQueryable<Product> products)
        {
            return products.Where(p => !p.IsDiscontinued && p.UnitPrice!=null);
        }

        public static IQueryable<Product> BestSelling(this IQueryable<Product> products)
        {
            return products.OrderByDescending(p => p.OrderDetails.Sum(d => d.Quantity));
        }
    }
}
