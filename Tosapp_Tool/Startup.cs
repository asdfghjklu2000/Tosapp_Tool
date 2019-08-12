using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tosapp_Tool.Startup))]
namespace Tosapp_Tool
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
