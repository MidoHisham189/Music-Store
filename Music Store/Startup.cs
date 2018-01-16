using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Music_Store.Startup))]
namespace Music_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
