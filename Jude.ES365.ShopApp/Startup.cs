using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jude.ES365.ShopApp.Startup))]
namespace Jude.ES365.ShopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
