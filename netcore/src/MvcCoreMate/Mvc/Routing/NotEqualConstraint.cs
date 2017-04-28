using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MvcCoreMate.Mvc.Routing
{
    /// <summary>
    /// Enables you to prevent a controller to be considered when ASP.NET routing determines whether a URL matches a route.
    /// </summary>
    public class NotEqualConstraint : IRouteConstraint
    {
        /// <summary>
        /// GEts or sets the pattern to be matched
        /// </summary>
        public string Pattern { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Methnology.Web.Routing.NotEqualConstraint class by using 
        /// the text that will be matched when evaluating the constraint.
        /// </summary>
        /// <param name="pattern">The text that will be matched when evaluating the constraint</param>
        public NotEqualConstraint(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("", nameof(pattern));

            this.Pattern = pattern;
        }

        /// <summary>
        /// Determines whether the request is associated to a parameter that is one of the ones not allowed for the route.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <param name="route">The object that this constraint belongs to.</param>
        /// <param name="routeKey">The name of the parameter that is being checked.</param>
        /// <param name="values">An object that contains the parameters for the URL.</param>
        /// <param name="routeDirection">An object that indicates whether the constraint check is being performed when an incoming request is being handled or when a URL is being generated.</param>
        /// <returns>
        /// When ASP.NET routing is processing a request, false if the request is associated to a parameter that is allowed for the route; otherwise, true. 
        /// </returns>
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));
            if (route == null)
                throw new ArgumentNullException(nameof(route));
            if (string.IsNullOrWhiteSpace(routeKey))
                throw new ArgumentException(nameof(routeKey));
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return String.Compare(values[routeKey].ToString(), Pattern, true) != 0;
        }
    }
}
