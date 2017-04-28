using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MvcCoreMate.Mvc
{
    /// <summary>
    /// Represents a class that is used to send JSON-formatted content to the response.
    /// </summary>
    public class JsonpResult : IActionResult
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MvcMate.Web.Mvc.JsonpResult class.
        /// </summary>
        /// <param name="data">The object to be serialized.</param>
        public JsonpResult(object data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the System.Web.Mvc.ActionResult class.
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="System.ArgumentNullException">The context parameter is null.</exception>
        public Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var serializer = new JsonSerializer();
            var callbackName = context.HttpContext.Request.Query["callback"];
            var jsonp = serializer.ToJsonpString(this.Data, callbackName);
            context.HttpContext.Response.ContentType = "application/json";
            return context.HttpContext.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(jsonp), 0, jsonp.Length);
        }
    }
}
