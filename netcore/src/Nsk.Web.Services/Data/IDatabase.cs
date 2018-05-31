using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Nsk.Web.Services.Data
{
    public interface IDatabase
    {
        Image<Rgba32> GetCategoryThumbnail(int categoryId);

        Image<Rgba32> GetProductThumbnail(int productId);
    }
}
