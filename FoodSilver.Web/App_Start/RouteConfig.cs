using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodSilver.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignore some type of request, the parm is route template
            // {} placeholder is parameter so it can take any val, {*} '*' is wildcard char and is match any thing follow like: "trace.axd/1/2/3" so it take all 1/2/3
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                // this route we give it name Default
                name: "Default",

                // home/contact/1 will serch for home + controller and etc..
                url: "{controller}/{action}/{id}",

                // id is considered optional so i dont need to have id to reach the end point
                // this is anonymos type that mvc will use it's values if the request does not have values: home/ || home/comtact/ || home/comtact/1
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
