using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AddressForm.MvcWeb.Models
{
    public class AddressFormDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Person> People { get; set; }


        public AddressFormDbContext()
            : base("name=AddressFormDbContext")
        {
        }
    }
}