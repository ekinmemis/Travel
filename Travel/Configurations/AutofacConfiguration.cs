using Autofac;
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
using System.Web.Mvc;

namespace Travel.Configurations
{
    public class AutofacConfiguration
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationUserService>().As<IApplicationUserService>();
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<AboutService>().As<IAboutService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<SliderService>().As<ISliderService>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                       .Where(t => t.Name.EndsWith("Controller"));

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}