using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nsk.OnlineStore.Web.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SiteMap",
                url: "sitemap",
                defaults: new { controller = "Home", action = "SiteMap" },
                namespaces: new string[] { "Nsk.OnlineStore.Web.Site.Controllers" }
            );

            routes.MapRoute(
                name: "ProductsByCategory",
                url: "catalog/c/{categoryId}/{categoryName}",
                defaults: new { controller = "Catalog", action = "ProductsByCategory", categoryName = UrlParameter.Optional },
                constraints: new { categoryId = @"\d+" }
            );

            routes.MapRoute(
                name: "ProductsBySupplier",
                url: "catalog/s/{supplierId}/{supplierName}",
                defaults: new { controller = "Catalog", action = "ProductsBySupplier", supplierName = UrlParameter.Optional },
                constraints: new { supplierId = @"\d+" }
            );

            routes.MapRoute(
                name: "ProductPage",
                url: "product/{productId}/{productName}",
                defaults: new { controller = "Catalog", action = "ProductDetail", productName = UrlParameter.Optional },
                constraints: new { productId = @"\d+" }
            );

            routes.MapRoute(
                name: "ProductsRssFeed",
                url: "products/rss",
                defaults: new { controller = "Catalog", action = "Rss" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Nsk.OnlineStore.Web.Site.Controllers" }
            );
        }
    }
}
