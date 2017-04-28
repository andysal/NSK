using Microsoft.AspNetCore.Mvc;
using MvcCoreMate.Mvc.Model;

namespace MvcCoreMate.Mvc
{
    /// <summary>
    /// Provides extensions for ASP.NET MVC Controller class in order to add support
    /// for new types of ActionResult
    /// </summary>
    public static class ControllerExtensions
    {
        ///// <summary>
        ///// Creates a Methnology.Web.Mvc.Atom10Result object that serializes the specified feed 
        ///// to Atom Syndication Format (ATOM) format.
        ///// </summary>
        ///// <param name="controller">The controller instance</param>
        ///// <param name="feed">The SyndicationFeed object graph to serialize.</param>
        ///// <returns>The Atom10Result result object that serializes the specified feed to ATOM format.</returns>
        //public static Atom10Result Atom10(this Controller controller, SyndicationFeed feed)
        //{
        //    return new Atom10Result(feed);
        //}

        ///// <summary>
        ///// Creates a Methnology.Web.Mvc.ImageResult object that serializes the specified System.Drawing.Image 
        ///// to an image embedded in the http response
        ///// </summary>
        ///// <param name="controller">The controller instance</param>
        ///// <param name="image">The image to be serialized</param>
        ///// <param name="mimeType">The mime type of the http response</param>
        ///// <returns>The ImageResult result object that serializes the specified image.</returns>
        //public static ImageResult Image(this Controller controller, Image image, string mimeType)
        //{
        //    return new ImageResult(image, mimeType);
        //}

        ///// <summary>
        ///// Creates a Methnology.Web.Mvc.ImageResult object that resizes and serializes the specified System.Drawing.Image 
        ///// to an image embedded in the http response
        ///// </summary>
        ///// <param name="controller">The controller instance</param>
        ///// <param name="image">The image to be serialized</param>
        ///// <param name="mimeType">The mime type of the http response</param>
        ///// <param name="thumbnailSize">The size of the thumbnail</param>
        ///// <returns>The ImageResult result object that serializes the specified image.</returns>
        //public static ImageResult Image(this Controller controller, Image image, string mimeType, Size thumbnailSize)
        //{
        //    return new ImageResult(image, mimeType, thumbnailSize);
        //}

        ///// <summary>
        ///// Creates a System.Web.Mvc.JsonResult object that serializes the specified object to JavaScript Object Notation (JSON).
        ///// </summary>
        ///// <param name="controller"></param>
        ///// <param name="data">The JavaScript object graph to serialize.</param>
        ///// <returns>
        ///// The JSONP result object that serializes the specified object to JSONP format. 
        ///// The result object that is prepared by this method is written to the response 
        ///// by the ASP.NET MVC framework when the object is executed.
        ///// </returns>
        //public static JsonpResult Jsonp(this Controller controller, object data)
        //{
        //    return new JsonpResult(data);
        //}

        /// <summary>
        /// Creates a Methnology.Web.Mvc.Rss20Result object that serializes the specified feed 
        /// to Really Simple Syndication (RSS) format.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="feed">The SyndicationFeed object graph to serialize.</param>
        /// <returns>The Rss20Result result object that serializes the specified feed to RSS format.</returns>
        public static RssResult Rss(this Controller controller, SyndicationFeed feed)
        {
            return new RssResult(feed);
        }
    }
}
