using Microsoft.AspNet.Identity.EntityFramework;

namespace AddressForm.MvcWeb.Models
{
    public class AddressFormDbContext : IdentityDbContext<ApplicationUser>
    {
        public AddressFormDbContext()
            : base("name=AddressFormDbContext")
        {
        }
    }
}