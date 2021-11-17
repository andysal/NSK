using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nsk.OnlineStore.Web.Site
{
    public static class UrlHelperExtensions
    {
        public static string Beautify(string url)
        {
            string beautifiedUrl = url.Replace(" ", "-").Replace("'", "-").Replace("/", "-").Replace(".", "-").Replace(",", "-").Replace("--", "-").Replace("@", "-at-").Replace(":", "").Replace("?", "").Replace("%", "").Replace("&", "-and-").Replace("&amp;", "-and-").Replace("\"", "").Replace("\\", "").Replace("(", "").Replace(")", "");
            return beautifiedUrl;
        }

        public static string Beautify(this UrlHelper helper, string url)
        {
            //string beautifiedUrl = url.Replace(" ", "-")
            //                            .Replace("'", "-")
            //                            .Replace("/", "-")
            //                            .Replace(".", "-")
            //                            .Replace(",", "-")
            //                            .Replace("--", "-")
            //                            .Replace("@", "-at-")
            //                            .Replace(":", "")
            //                            .Replace("?", "")
            //                            .Replace("%", "")
            //                            .Replace("&", "-and-")
            //                            .Replace("&amp;", "-and-")
            //                            .Replace("\"", "")
            //                            .Replace("\\", "");
            string beautifiedUrl = Beautify(url);
            return helper.Encode(beautifiedUrl);
        }
    }
}