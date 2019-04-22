namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validatio_added_to_itemCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ItemCategories", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemCategories", "Code", c => c.String());
            AlterColumn("dbo.ItemCategories", "Name", c => c.String());
        }
    }
}
