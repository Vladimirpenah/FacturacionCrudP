using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SysFacturacion.Startup))]
namespace SysFacturacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
