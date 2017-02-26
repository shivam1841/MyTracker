using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OEMS.Startup))]
namespace OEMS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
