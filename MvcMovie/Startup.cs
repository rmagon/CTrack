using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCTrack.Startup))]
namespace MvcCTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
