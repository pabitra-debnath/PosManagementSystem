namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Total_Price_added_to_purchaseDetailes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseDetails", "TotalPrice");
        }
    }
}
