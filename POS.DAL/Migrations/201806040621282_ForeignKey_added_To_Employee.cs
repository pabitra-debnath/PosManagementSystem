namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_added_To_Employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "OrganizationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "OrganizationId");
        }
    }
}
