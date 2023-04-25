﻿using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.AppGlobalization.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IdentityProfileApp.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "LocalizedDefault",
               url: "{lang}/{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { lang = "tr-TR|en-Us" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { lang = "tr-TR", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
