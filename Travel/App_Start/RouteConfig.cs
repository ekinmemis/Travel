using System.Web.Mvc;
using System.Web.Routing;

namespace Travel
{
    /// <summary>
    /// Defines the <see cref="RouteConfig" />.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The RegisterRoutes.
        /// </summary>
        /// <param name="routes">The routes<see cref="RouteCollection"/>.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "giris",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
