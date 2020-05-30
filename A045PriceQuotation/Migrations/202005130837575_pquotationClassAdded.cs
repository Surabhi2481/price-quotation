namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pquotationClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pquotations",
                c => new
                    {
                        quotationid = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        userId = c.String(),
                        vendorId = c.String(),
                        name = c.String(),
                        description = c.String(),
                        availability = c.Boolean(nullable: false),
                        category = c.Int(nullable: false),
                        color = c.String(),
                        quantity = c.Int(),
                        quotation = c.Int(),
                        status = c.String(),
                        vendorStatus = c.String(),
                    })
                .PrimaryKey(t => t.quotationid)
                .ForeignKey("dbo.products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pquotations", "productId", "dbo.products");
            DropIndex("dbo.pquotations", new[] { "productId" });
            DropTable("dbo.pquotations");
        }
    }
}
