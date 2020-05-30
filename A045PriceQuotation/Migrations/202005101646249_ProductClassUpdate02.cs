namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductClassUpdate02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        userId = c.String(nullable: false, maxLength: 20),
                        name = c.String(nullable: false),
                        category = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 500),
                        availability = c.Boolean(nullable: false),
                        quantity = c.Int(nullable: false),
                        color = c.String(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.mainClasses", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "userId", "dbo.mainClasses");
            DropIndex("dbo.products", new[] { "userId" });
            DropTable("dbo.products");
        }
    }
}
