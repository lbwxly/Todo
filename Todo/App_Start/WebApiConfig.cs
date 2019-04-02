using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Todo.Infrastructure;
using Todo.Infrastructure.Auth;

namespace Todo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new RequestMonitorHandler());
            //config.MessageHandlers.Add(new AuthenticationHandler());
            //config.Filters.Add(new ErrorHandlingFilter());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
