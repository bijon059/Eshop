using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Shop_Project.Startup))]
namespace E_Shop_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
