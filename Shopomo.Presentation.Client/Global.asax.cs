using Shopomo.OTP.Infra.IoC;
using Shopomo.Presentation.Client.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shopomo.Presentation.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region Dependency Injection

            var container = new Container();

            BootStrapper.Register(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            #endregion

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
