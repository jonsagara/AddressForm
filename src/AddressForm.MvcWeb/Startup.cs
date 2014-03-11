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

#if !DEBUG
            // Only do automatic migrations when in RELEASE mode. When developing, force
            //  the developer to apply them manually.
            DoMigrations();
#endif
        }
    }
}
