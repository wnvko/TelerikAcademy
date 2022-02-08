using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Switter.Web.Startup))]
namespace Switter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
