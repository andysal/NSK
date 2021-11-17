using System;
using Microsoft.Extensions.Configuration;

namespace Nsk.Web.Site
{
    public class UrlBuilder
    {
        public IConfiguration Configuration { get; private set; }
        string baseUrl;

        public UrlBuilder(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            baseUrl = Configuration.GetValue<string>("ImageBaseUrl");

        }

        public string BuildProductsByCategoryPageUrl(int categoryId, string categoryName)
        {
            return string.Format("/catalog/c/{0}/{1}", categoryId, UrlHelperExtensions.Beautify(categoryName));
        }

        public string BuildProductsBySupplierPageUrl(int supplierId, string supplierName)
        {
            return string.Format("/catalog/s/{0}/{1}", supplierId, UrlHelperExtensions.Beautify(supplierName));
        }

        public string BuildProductPageUrl(int productId, string productName)
        {
            return string.Format("/product/{0}/{1}", productId, UrlHelperExtensions.Beautify(productName));
        }

        public string BuildCategoryThumbnailUrl(int categoryId)
        {
            return $"{baseUrl}/image/category/{categoryId})";
        }

        public string BuildProductThumbnailUrl(int productId)
        {
            return $"{baseUrl}/image/product/{productId}";
        }

        public string BuildSearchResultPageUrl(string query)
        {
            return $"/s/{query}";
        }
    }
}