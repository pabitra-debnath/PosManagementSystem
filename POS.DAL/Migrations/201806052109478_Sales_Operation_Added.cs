namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sales_Operation_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesOperationInfoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SalesNo = c.String(nullable: false),
                        BranchId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        CustomerName = c.String(),
                        CustomerContact = c.String(),
                        TotalAmount = c.Double(nullable: false),
                        VAT = c.Double(),
                        DiscountAmount = c.Double(),
                        PayableAmount = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.BranchId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.SalesOperations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Quantity = c.Long(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        LineTotal = c.Double(nullable: false),
                        Date = c.DateTime(),
                        SalesOperationInformationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOperationInfoes", t => t.SalesOperationInformationId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.SalesOperationInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOperations", "SalesOperationInformationId", "dbo.SalesOperationInfoes");
            DropForeignKey("dbo.SalesOperations", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SalesOperationInfoes", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.SalesOperationInfoes", "BranchId", "dbo.Branches");
            DropIndex("dbo.SalesOperations", new[] { "SalesOperationInformationId" });
            DropIndex("dbo.SalesOperations", new[] { "ItemId" });
            DropIndex("dbo.SalesOperationInfoes", new[] { "Employee_Id" });
            DropIndex("dbo.SalesOperationInfoes", new[] { "BranchId" });
            DropTable("dbo.SalesOperations");
            DropTable("dbo.SalesOperationInfoes");
        }
    }
}
