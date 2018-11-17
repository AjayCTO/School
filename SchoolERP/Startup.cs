using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolERP.Startup))]
namespace SchoolERP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
