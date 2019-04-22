namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ExpenseItem_Branch_Party_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Contact = c.String(),
                        Address = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrganizationId = c.Long(nullable: false),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PreCode = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PreCode = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Contact = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Image = c.Binary(),
                        Date = c.DateTime(nullable: false),
                        IsCustomer = c.Boolean(nullable: false),
                        IsSupplier = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "Category_Id", "dbo.ExpenseCategories");
            DropForeignKey("dbo.Branches", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.ExpenseItems", new[] { "Category_Id" });
            DropIndex("dbo.Branches", new[] { "Organization_Id" });
            DropTable("dbo.Parties");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.Branches");
        }
    }
}
