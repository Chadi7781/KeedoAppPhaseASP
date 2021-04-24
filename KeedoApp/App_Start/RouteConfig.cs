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

            /*
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //CLient
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "IndexClient", id = UrlParameter.Optional }
            );*/

            //ADmin
            
                        routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


                        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");         

        }
    }
}