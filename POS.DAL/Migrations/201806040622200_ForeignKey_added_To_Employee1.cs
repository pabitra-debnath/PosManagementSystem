namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_added_To_Employee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Branchs_Id", c => c.Long());
            CreateIndex("dbo.Employees", "OrganizationId");
            CreateIndex("dbo.Employees", "Branchs_Id");
            AddForeignKey("dbo.Employees", "Branchs_Id", "dbo.Branches", "Id");
            AddForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "Branchs_Id", "dbo.Branches");
            DropIndex("dbo.Employees", new[] { "Branchs_Id" });
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropColumn("dbo.Employees", "Branchs_Id");
        }
    }
}
