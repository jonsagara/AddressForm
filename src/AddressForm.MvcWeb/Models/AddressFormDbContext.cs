using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AddressForm.MvcWeb.Models
{
    public class AddressFormDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }


        public AddressFormDbContext()
            : base("name=AddressFormDbContext")
        {
        }
    }
}