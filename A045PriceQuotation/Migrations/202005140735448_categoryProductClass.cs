namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryProductClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoryProducts",
                c => new
                    {
                        i = c.Int(nullable: false, identity: true),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.i);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.categoryProducts");
        }
    }
}
