using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Leanwork.CodePack.Mvc
{
    public static class RouteTableExtensions
    {
        public static IEnumerable<CustomRoute> GetAdminRoutes(this RouteCollection routeTable)
        {
            return routeTable.OfType<CustomRoute>();
        }
    }
}