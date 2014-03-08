using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddressForm.MvcWeb.Startup))]
namespace AddressForm.MvcWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
