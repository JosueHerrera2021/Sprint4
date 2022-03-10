using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sprint4.Startup))]
namespace Sprint4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
