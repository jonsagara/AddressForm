namespace AddressForm.MvcWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 2),
                        Alpha3Code = c.String(maxLength: 3),
                        NumericCode = c.String(maxLength: 3),
                        Iso3166_2Code = c.String(maxLength: 13),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryId = c.String(maxLength: 2),
                        Abbreviation = c.String(maxLength: 2),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Regions", new[] { "CountryId" });
            DropTable("dbo.Regions");
            DropTable("dbo.People");
            DropTable("dbo.Countries");
        }
    }
}
