using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiMysql.Providers;

namespace WebApiMysql
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // custom JSON
            var json = config.Formatters.JsonFormatter;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MessageHandlers.Add(new PreflightRequestsHandler());
        }
    }
}
