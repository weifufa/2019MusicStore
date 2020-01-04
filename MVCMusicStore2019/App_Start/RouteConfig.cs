using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCMusicStore2019
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
               name: "ShoppingCart",
               url: "ShoppingCart/Index",
               defaults: new { controller = "ShoppingCart", action = "Index" },
               constraints:new {httpMethod=new HttpMethodConstraint("GET") }
           );
            routes.MapRoute(
              name: "MusicIndex",
              url: "MusicIndex/Index",
              defaults: new { controller = "MusicIndex", action = "Index" },
                  constraints:new { httpMethod = new HttpMethodConstraint("GET") }
          );
            routes.MapRoute(
           name: "Detail",
           url: "MusicIndex/Detail",
           defaults: new { controller = "MusicIndex", action = "Detail" },
               constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );
       routes.MapRoute(
              name: "CheckOut",
              url: "Order/CheckOut",
              defaults: new { controller = "Order", action = "CheckOut" },
                  constraints:new { httpMethod = new HttpMethodConstraint("POST") }
          );

            routes.MapRoute(
             name: "GetAlbumUrl",
             url: "ShoppingCart/GetAlbumUrl",
             defaults: new { controller = "ShoppingCart", action = "GetAlbumUrl" },
                 constraints:new { httpMethod = new HttpMethodConstraint("POST") }
         );


        }
    }
}
