namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization_added_to_Purchase_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "OrganizationId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "OrganizationId");
        }
    }
}
