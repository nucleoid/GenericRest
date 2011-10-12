using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GenericRest
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RouteRegistry.RegisterRoutes(RouteTable.Routes);
        }
    }
}