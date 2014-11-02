using System.Data.Entity;

namespace AddressForm.MvcWeb.Models
{
    public class AddressFormDbContext : DbContext
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