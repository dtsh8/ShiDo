using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShiDo.Startup))]
namespace ShiDo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
