using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingList_Team2_Master
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "ListItems",
            //    url: "ListModels/Details/{id}/Items/{listId}",
            //    defaults: new { controller = "ListModels", action = "ItemDetails" });

            //routes.MapRoute(
            //    name: "CreateItem",
            //    url: "ListModels/Details/{id}/Items/Create",
            //    defaults: new { controller = "ListModels", action = "CreateItem" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
