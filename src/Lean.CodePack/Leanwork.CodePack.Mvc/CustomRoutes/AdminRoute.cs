using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Leanwork.CodePack.Mvc
{
    public class CustomRoute : Route
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public CustomRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler) { }
    }

    public static class AreaRegistrationContextExtensions
    {
        public static void MapCustomRoute(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces, string group = "")
        {
            context.MapCustomRoute(name, url, defaults, null, namespaces, group: group);
        }

        public static void MapCustomRoute(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces, string group = "")
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (url == null)
                throw new ArgumentNullException("url");

            var route = new CustomRoute(url, new MvcRouteHandler())
            {
                Name = name,
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(),
                Group = group
            };

            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }
            route.DataTokens["area"] = context.AreaName;

            if (String.IsNullOrEmpty(name))
                context.Routes.Add(route);
            else
                context.Routes.Add(name, route);
        }
    }
}