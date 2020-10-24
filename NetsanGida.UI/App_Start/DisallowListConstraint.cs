using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace NetsanGida.UI.App_Start
{
    public class DisallowListConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;

        public DisallowListConstraint(string options)
        {
            options = "adminsefaveysel|hakkinda|sss|galeri|iletisim|urundetay|duyuru|urunler";
            options += "";
            validOptions = options.Split('|');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return !validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}