using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cashing.Startup))]
namespace Cashing
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
