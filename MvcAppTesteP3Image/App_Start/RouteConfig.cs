﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcAppTesteP3Image
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "Home",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin",
                defaults: new { controller = "Home", action = "Admin" }
            );

            routes.MapRoute(
                name: "Slug",
                url: "{catslug}/{subcatslug}",
                defaults: new { controller = "Home", action = "Form", catslug = "", subcatslug = "" }
            );
        }
    }
}
