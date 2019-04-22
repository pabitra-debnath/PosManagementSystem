namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Branch_ForeignKey_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branches", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.Branches", new[] { "Organization_Id" });
            DropColumn("dbo.Branches", "OrganizationId");
            RenameColumn(table: "dbo.Branches", name: "Organization_Id", newName: "OrganizationId");
            AlterColumn("dbo.Branches", "OrganizationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Branches", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "OrganizationId");
            AddForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            AlterColumn("dbo.Branches", "OrganizationId", c => c.Int());
            AlterColumn("dbo.Branches", "OrganizationId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Branches", name: "OrganizationId", newName: "Organization_Id");
            AddColumn("dbo.Branches", "OrganizationId", c => c.Long(nullable: false));
            CreateIndex("dbo.Branches", "Organization_Id");
            AddForeignKey("dbo.Branches", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
