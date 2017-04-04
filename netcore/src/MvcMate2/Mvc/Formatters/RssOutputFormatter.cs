using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using MvcMate2.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMate2.Mvc.Formatters
{
    public class RssOutputFormatter : OutputFormatter
    { 

        public RssOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/rss+xml"));
            //SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            
            var rss = GetXml((SyndicationFeed) context.Object);
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            response.ContentLength = rss.Length;
            return response.Body.WriteAsync(Encoding.ASCII.GetBytes(rss), 0, rss.Length);
        }

        private string GetXml(SyndicationFeed feed)
        {
            var buf = new StringBuilder();
            buf.Append("<rss version=\"2.0\">");
            buf.Append("<channel>");
            buf.Append(string.Format("<title>{0}</title>", feed.Title));
            buf.Append("</channel>");
            buf.Append("</rss>");
            return buf.ToString();
        }
    }
}
