using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KeedoApp
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
            routes.MapRoute(
               name: "ManageEvent",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Event", action = "ManageEvent", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "RouteEvent",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Event", action = "DetailEvent", id = UrlParameter.Optional }
            );

        }
    }
}
