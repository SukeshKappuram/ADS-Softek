using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EshoppingV2._0.Startup))]
namespace EshoppingV2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
