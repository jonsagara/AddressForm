
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using AddressForm.MvcWeb.Migrations;
using AddressForm.MvcWeb.Models;

namespace AddressForm.MvcWeb
{
    public partial class Startup
    {
        private static void DoMigrations()
        {
            Database.SetInitializer<AddressFormDbContext>(null);

            var migrator = new DbMigrator(new Configuration());
            if (migrator.GetPendingMigrations().Any())
            {
                migrator.Update();
            }
        }
    }
}