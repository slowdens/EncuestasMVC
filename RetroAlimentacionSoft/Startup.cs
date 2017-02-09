using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RetroAlimentacionSoft.Startup))]
namespace RetroAlimentacionSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
