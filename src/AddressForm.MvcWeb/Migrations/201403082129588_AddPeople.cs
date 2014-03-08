namespace AddressForm.MvcWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeople : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        StreetAddress = c.String(maxLength: 100),
                        ExtendedAddress = c.String(maxLength: 100),
                        Locality = c.String(maxLength: 50),
                        Region = c.String(maxLength: 50),
                        PostalCode = c.String(maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
