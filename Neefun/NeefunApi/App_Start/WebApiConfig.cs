using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NeefunApi.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace NeefunApi
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

            // Odata routes
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("Person");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());

        }
    }
}
