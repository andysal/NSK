using Microsoft.AspNetCore.Mvc;
using MvcCoreMate.Mvc.Model;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreMate.Mvc
{
    public class RssResult : IActionResult
    {
        /// <summary>
        /// Gets or sets the feed
        /// </summary>
        public SyndicationFeed Feed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MvcMate.Web.Mvc.Rss20Result class.
        /// </summary>
        /// <param name="feed">The feed to be serialized to RSS format</param>
        public RssResult(SyndicationFeed feed)
        {
            if (feed == null)
                throw new ArgumentNullException("feed");

            this.Feed = feed;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var rss = GetXml(this.Feed);
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
            buf.Append($"<title>{feed.Title}</title>");
            foreach(var item in feed.Items)
            {
                buf.Append("<item>");
                buf.Append($"<title>{item.Title}</title>");
                buf.Append("</item>");
            }
            buf.Append("</channel>");
            buf.Append("</rss>");
            return buf.ToString();
        }
    }
}
