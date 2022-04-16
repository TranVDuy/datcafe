using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(duycoffee.Startup))]
namespace duycoffee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
