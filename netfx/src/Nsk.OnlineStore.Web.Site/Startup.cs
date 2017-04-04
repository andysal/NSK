using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nsk.OnlineStore.Web.Site.Startup))]
namespace Nsk.OnlineStore.Web.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
