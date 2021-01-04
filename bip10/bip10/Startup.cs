using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bip10.Startup))]
namespace bip10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
