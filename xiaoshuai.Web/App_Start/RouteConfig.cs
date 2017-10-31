using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace xiaoshuai.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("ListRoute", "{controller}/{action}/{id}/{subid}.html", new { controller = "Home", action = "List" }, new { subid = @"^[a-zA-Z][0-9]*$" });
            routes.MapRoute("ArticleRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Article", id = UrlParameter.Optional });
        }
    }
}