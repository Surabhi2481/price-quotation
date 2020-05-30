namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        accNumber = c.String(nullable: false, maxLength: 16),
                        name = c.String(nullable: false),
                        address = c.String(nullable: false),
                        balance = c.Double(nullable: false),
                        debitcardNumber = c.Int(nullable: false),
                        creditcardNumber = c.Int(),
                        phoneNumber = c.String(),
                        debitcvv = c.Int(nullable: false),
                        creditcvv = c.Int(nullable: false),
                        debitpin = c.Int(nullable: false),
                        creditpin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.accNumber);
            
            CreateTable(
                "dbo.bills",
                c => new
                    {
                        payId = c.Int(nullable: false, identity: true),
                        quotationId = c.Int(nullable: false),
                        billDate = c.DateTime(nullable: false),
                        paymentMode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.payId)
                .ForeignKey("dbo.pquotations", t => t.quotationId, cascadeDelete: true)
                .Index(t => t.quotationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.bills", "quotationId", "dbo.pquotations");
            DropIndex("dbo.bills", new[] { "quotationId" });
            DropTable("dbo.bills");
            DropTable("dbo.accounts");
        }
    }
}
