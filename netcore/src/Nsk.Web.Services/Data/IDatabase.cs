using System.Linq;
using System.Drawing;

namespace Nsk.Web.Services.Data
{
    public interface IDatabase
    {
        Image GetCategoryThumbnail(int categoryId);

        Image GetProductThumbnail(int productId);
    }
}
