using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeDB_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "values", id = RouteParameter.Optional }

           );
            config.Routes.MapHttpRoute(
               name: "DeltApi",
               routeTemplate: "api/{controller}/{surname}",
               defaults: new { controller = "values", surname = RouteParameter.Optional }
           );
        }
    }
}
