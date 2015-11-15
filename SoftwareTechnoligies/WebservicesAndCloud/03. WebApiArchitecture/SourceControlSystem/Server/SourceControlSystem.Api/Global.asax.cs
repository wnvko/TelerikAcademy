namespace SourceControlSystem.Api
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using Common.Constants;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
