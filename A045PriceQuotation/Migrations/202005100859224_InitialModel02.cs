namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.users",
                c => new
                    {
                        i = c.Int(nullable: false, identity: true),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.i);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
        }
    }
}
