namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mainClasses",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 20),
                        firstName = c.String(nullable: false, maxLength: 25),
                        lastName = c.String(nullable: false, maxLength: 25),
                        gender = c.Int(nullable: false),
                        contactNumber = c.String(nullable: false, maxLength: 10),
                        password = c.String(nullable: false, maxLength: 20),
                        address = c.String(nullable: false, maxLength: 50),
                        mapLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.mainClasses");
        }
    }
}
