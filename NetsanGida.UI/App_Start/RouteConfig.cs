using NetsanGida.UI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace NetsanGida.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("disallow", typeof(DisallowListConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapRoute(
               name: "UrlRewrite",
               url: "{urunUrl}",
               defaults: new { controller = "Product", action = "Detail" },
               namespaces: new string[] { "NetsanGida.Ui.Controllers" }

               );

            routes.MapRoute(
               name: "UrlCategory",
               url: "{kategoriUrl}",
               defaults: new { controller = "Product", action = "GetProducts" },
               namespaces: new string[] { "NetsanGida.Ui.Controllers" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NetsanGida.Ui.Controllers" }
            );
        }
    }
}
