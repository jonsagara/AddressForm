using AddressForm.MvcWeb.Models.Seed;

namespace AddressForm.MvcWeb.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AddressForm.MvcWeb.Models.AddressFormDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AddressForm.MvcWeb.Models.AddressFormDbContext context)
        {
            CountrySeeder.SeedCountries(context);
            RegionSeeder.SeedRegions(context);
        }
    }
}
