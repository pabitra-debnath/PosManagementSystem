namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation_Remove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemCategories", "Name", c => c.String());
            AlterColumn("dbo.ItemCategories", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemCategories", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.ItemCategories", "Name", c => c.String(nullable: false));
        }
    }
}
