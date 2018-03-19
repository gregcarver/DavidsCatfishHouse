using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DavidsCatfishHouse.Startup))]
namespace DavidsCatfishHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
