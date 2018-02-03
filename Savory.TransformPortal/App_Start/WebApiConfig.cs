using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Savory.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Savory.WebApi;

namespace Savory.TransformPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new SameRefferAuthorityFilterAttribute());
            config.Filters.Add(new HandleApiExceptionAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}