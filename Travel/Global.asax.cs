using System.Web.Mvc;
using System.Web.Routing;

using Travel.Configurations;
using Travel.Infrastructure;

using static Travel.Infrastructure.CustomSearchModelBinding;

namespace Travel
{
    /// <summary>
    /// Defines the <see cref="MvcApplication" />.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The Application_Start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinderProviders.BinderProviders.Insert(0, new DataTablesToObjectModelBinderProvider());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            AutofacConfiguration.Init();
            AutoMapperConfiguration.Init();
        }
    }
}