using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicoCL.Startup))]
namespace MedicoCL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
