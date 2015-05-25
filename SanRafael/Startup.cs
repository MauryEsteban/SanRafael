using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SanRafael.Startup))]
namespace SanRafael
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
