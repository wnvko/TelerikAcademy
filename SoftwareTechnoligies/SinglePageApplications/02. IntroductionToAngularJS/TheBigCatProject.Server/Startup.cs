using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(TheBigCatProject.Server.Startup))]

namespace TheBigCatProject.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); 
            ConfigureAuth(app);
        }
    }
}
