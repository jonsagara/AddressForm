namespace AddressForm.MvcWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountriesAndRegions : DbMigration
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
            DropTable("dbo.Countries");
        }
    }
}
