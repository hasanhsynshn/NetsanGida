using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetsanGida.UI.Startup))]
namespace NetsanGida.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
