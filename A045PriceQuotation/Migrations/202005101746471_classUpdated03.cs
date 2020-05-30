namespace A045PriceQuotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classUpdated03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.mainClasses", "dob", c => c.DateTime());
            AddColumn("dbo.mainClasses", "status", c => c.String(nullable: false));
            AddColumn("dbo.mainClasses", "categoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.mainClasses", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.mainClasses", "password", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.mainClasses", "categoryId");
            DropColumn("dbo.mainClasses", "status");
            DropColumn("dbo.mainClasses", "dob");
        }
    }
}
