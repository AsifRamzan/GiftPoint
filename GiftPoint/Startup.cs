using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiftPoint.Startup))]
namespace GiftPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
