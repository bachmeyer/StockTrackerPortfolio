namespace StockTrackerFourLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "DateCreated");
        }
    }
}
