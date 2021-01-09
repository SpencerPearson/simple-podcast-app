using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimplePodcastApp.UI.MVC.Startup))]
namespace SimplePodcastApp.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
