using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopomo.Presentation.Admin.Startup))]
namespace Shopomo.Presentation.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
