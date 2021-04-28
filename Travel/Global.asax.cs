using Autofac;
using Autofac.Core.Activators.Reflection;
using Autofac.Integration.Mvc;
using Data.EfRepository;
using Service.Authentication;
using Services.AboutServices;
using Services.ApplicationUserServices;
using Services.BlogServices;
using Services.CategoryServices;
using Services.ContactServices;
using Services.SliderServices;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Travel.Configurations;
using Travel.Controllers;
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