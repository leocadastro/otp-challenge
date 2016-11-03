using Shopomo.Application.App;
using Shopomo.Application.Interfaces;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Domain.Interfaces.Services;
using Shopomo.OTP.Domain.Services;
using Shopomo.OTP.Infra.Data.Context;
using Shopomo.OTP.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace Shopomo.OTP.Infra.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            container.Options.AllowOverridingRegistrations = true;
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<ShopomoContext>(Lifestyle.Scoped);

            //Repositories
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<IUserRepository, UserRepository>();
            container.Register<ILoginRepository, LoginRepository>();

            //Services
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<IUserService, UserService>();
            container.Register<ILoginService, LoginService>();

            //Applications
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<IUserAppService, UserAppService>();
            container.Register<ILoginAppService, LoginAppService>();


        }
    }
}
