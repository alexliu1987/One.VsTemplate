using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof($safeprojectname$.Web.Startup))]
namespace $safeprojectname$.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
