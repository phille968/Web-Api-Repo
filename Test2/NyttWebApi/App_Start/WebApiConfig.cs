using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NyttWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
            config.Routes.MapHttpRoute(
            name: "AddAndRemoveUserToGroup",
             routeTemplate: "api/{controller}/{action}/{groupId}/{userId}"
            );

            config.Routes.MapHttpRoute(
            name: "ConfirmEmail",
             routeTemplate: "api/{controller}/{action}/{confirmationKeyId}"
            );

          
        }
    }
}
