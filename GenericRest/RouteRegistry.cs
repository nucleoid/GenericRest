using System.Web.Mvc;
using System.Web.Routing;

namespace GenericRest
{
    public static class RouteRegistry
    {
        private const string CustomerIdentityFieldConstraint = @"[a-zA-Z0-9]{8,10}";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "get-object",
                "{cif}/{controller}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { httpMethod = new HttpMethodConstraint("GET"), id = @"(\d)+", cif = CustomerIdentityFieldConstraint }
            );

            routes.MapRoute(
                "post-object",
                "{cif}/{controller}",
                new { action = "Save" },
                new { httpMethod = new HttpMethodConstraint("POST"), cif = CustomerIdentityFieldConstraint }
            );

            routes.MapRoute(
                "put-object",
                "{cif}/{controller}/{id}",
                new { action = "Save" },
                new { httpMethod = new HttpMethodConstraint("PUT"), cif = CustomerIdentityFieldConstraint }
            );

            routes.MapRoute(
                "delete-object",
                "{cif}/{controller}/{id}",
                new { action = "Delete" },
                new { httpMethod = new HttpMethodConstraint("DELETE"), cif = CustomerIdentityFieldConstraint }
            );

            routes.MapRoute(
                "default REST route", // Route name
                "{cif}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, cif = "00000000" }, // Parameter defaults
                new { cif = CustomerIdentityFieldConstraint }
            );
        }
    }
}