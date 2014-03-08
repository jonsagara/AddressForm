namespace AddressForm.MvcWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AddressForm.MvcWeb.Models.AddressFormDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AddressForm.MvcWeb.Models.AddressFormDbContext context)
        {
        }
    }
}
