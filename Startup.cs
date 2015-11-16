using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shell.Startup))]
namespace Shell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
