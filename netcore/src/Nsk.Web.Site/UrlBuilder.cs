namespace Nsk.Web.Site
{
    public static class UrlBuilder
    {
        static string baseUrl = "http://localhost:5002";
        //static string baseUrl = "http://NskWe-Recip-1GZ2THEA7IHVX-1990822341.eu-west-1.elb.amazonaws.com";
        public static string BuildProductsByCategoryPageUrl(int categoryId, string categoryName)
        {
            return string.Format("/catalog/c/{0}/{1}", categoryId, UrlHelperExtensions.Beautify(categoryName));
        }

        public static string BuildProductsBySupplierPageUrl(int supplierId, string supplierName)
        {
            return string.Format("/catalog/s/{0}/{1}", supplierId, UrlHelperExtensions.Beautify(supplierName));
        }

        public static string BuildProductPageUrl(int productId, string productName)
        {
            return string.Format("/product/{0}/{1}", productId, UrlHelperExtensions.Beautify(productName));
        }

        public static string BuildCategoryThumbnailUrl(int categoryId)
        {
            return $"{baseUrl}/image/category/{categoryId})";
        }

        public static string BuildProductThumbnailUrl(int productId)
        {
            return $"{baseUrl}/image/product/{productId}";
        }

        public static string BuildSearchResultPageUrl(string query)
        {
            return string.Format("/s/{0}", query);
        }
    }
}