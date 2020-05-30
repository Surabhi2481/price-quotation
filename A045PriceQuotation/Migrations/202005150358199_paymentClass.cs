namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentClass : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.accounts");
            AddColumn("dbo.accounts", "value", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "userId", c => c.String(maxLength: 20));
            AddColumn("dbo.accounts", "paymentMode", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "cardNumber", c => c.String(nullable: false, maxLength: 16));
            AddColumn("dbo.accounts", "amtPayable", c => c.Double(nullable: false));
            AddColumn("dbo.accounts", "cvv", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.accounts", "pin", c => c.String(nullable: false, maxLength: 4));
            AddPrimaryKey("dbo.accounts", "value");
            CreateIndex("dbo.accounts", "userId");
            AddForeignKey("dbo.accounts", "userId", "dbo.mainClasses", "userId");
            DropColumn("dbo.accounts", "address");
            DropColumn("dbo.accounts", "balance");
            DropColumn("dbo.accounts", "debitcardNumber");
            DropColumn("dbo.accounts", "creditcardNumber");
            DropColumn("dbo.accounts", "phoneNumber");
            DropColumn("dbo.accounts", "debitcvv");
            DropColumn("dbo.accounts", "creditcvv");
            DropColumn("dbo.accounts", "debitpin");
            DropColumn("dbo.accounts", "creditpin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.accounts", "creditpin", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "debitpin", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "creditcvv", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "debitcvv", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "phoneNumber", c => c.String());
            AddColumn("dbo.accounts", "creditcardNumber", c => c.Int());
            AddColumn("dbo.accounts", "debitcardNumber", c => c.Int(nullable: false));
            AddColumn("dbo.accounts", "balance", c => c.Double(nullable: false));
            AddColumn("dbo.accounts", "address", c => c.String(nullable: false));
            DropForeignKey("dbo.accounts", "userId", "dbo.mainClasses");
            DropIndex("dbo.accounts", new[] { "userId" });
            DropPrimaryKey("dbo.accounts");
            DropColumn("dbo.accounts", "pin");
            DropColumn("dbo.accounts", "cvv");
            DropColumn("dbo.accounts", "amtPayable");
            DropColumn("dbo.accounts", "cardNumber");
            DropColumn("dbo.accounts", "paymentMode");
            DropColumn("dbo.accounts", "userId");
            DropColumn("dbo.accounts", "value");
            AddPrimaryKey("dbo.accounts", "accNumber");
        }
    }
}
