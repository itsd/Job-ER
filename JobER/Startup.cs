using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobER.Startup))]
namespace JobER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
