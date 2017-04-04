using Microsoft.AspNetCore.Mvc.Routing;

namespace Nsk.Web.Site
{
    public static class UrlHelperExtensions
    {
        public static string Beautify(string url)
        {
            string beautifiedUrl = url
                                    .Replace(" ", "-")
                                    .Replace("'", "-")
                                    .Replace("/", "-")
                                    .Replace(".", "-")
                                    .Replace(",", "-")
                                    .Replace("--", "-")
                                    .Replace("@", "-at-")
                                    .Replace(":", "")
                                    .Replace("?", "")
                                    .Replace("%", "")
                                    .Replace("&", "-and-")
                                    .Replace("&amp;", "-and-")
                                    .Replace("\"", "")
                                    .Replace("\\", "")
                                    .Replace("(", "")
                                    .Replace(")", "");

            return beautifiedUrl;
        }

        public static string Beautify(this UrlHelper helper, string url)
        {
            string beautifiedUrl = Beautify(url);
            return System.Net.WebUtility.UrlEncode(url);
        }
    }
}
