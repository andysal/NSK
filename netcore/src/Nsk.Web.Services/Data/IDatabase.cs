using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Nsk.Web.Services.Data
{
    public interface IDatabase
    {
        Image GetCategoryThumbnail(int categoryId);

        Image GetProductThumbnail(int productId);
    }
}
