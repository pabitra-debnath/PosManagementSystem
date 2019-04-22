namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_model_modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            AlterColumn("dbo.Purchases", "OrganizationId", c => c.Int());
        }
    }
}
