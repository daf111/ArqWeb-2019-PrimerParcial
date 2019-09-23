using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcPet.UI.Website.Startup))]
namespace mvcPet.UI.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
