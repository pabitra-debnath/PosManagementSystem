namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PreCode = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        CostPrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropTable("dbo.Items");
        }
    }
}
