using System.Web.Mvc;
using System.Web.Routing;
using Travel.Infrastructure;
using static Travel.Infrastructure.CustomSearchModelBinding;

namespace Travel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinderProviders.BinderProviders.Insert(0, new DataTablesToObjectModelBinderProvider());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}
