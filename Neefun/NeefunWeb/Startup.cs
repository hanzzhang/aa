using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeefunWeb.Startup))]
namespace NeefunWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
