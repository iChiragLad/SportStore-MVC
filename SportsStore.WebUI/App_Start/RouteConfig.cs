using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null
                }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Product", action = "List"}
            );

            routes.MapRoute(
                null,
                "",
                new { controller = "Nav", action = "Menu" }
            );

            routes.MapRoute(null, "Cart/AddToCart", new { controller = "Cart", action = "AddToCart" });

            routes.MapRoute(null, "Cart/Index", new { controller = "Cart", action = "Index" });

            routes.MapRoute(null, "{controller}/{action}/{category}", new { controller = "Product", action = "List"});

        }
    }
}
