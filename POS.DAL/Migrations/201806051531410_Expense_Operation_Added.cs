namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense_Operation_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseOperationInfoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExpenseNo = c.String(nullable: false),
                        BranchId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.BranchId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.ExpenseOperations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Quantity = c.Long(nullable: false),
                        Amount = c.Double(nullable: false),
                        LineTotal = c.Double(nullable: false),
                        Reason = c.String(),
                        Date = c.DateTime(),
                        ExpenseInformationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseOperationInfoes", t => t.ExpenseInformationId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseItems", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.ExpenseInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseOperations", "ItemId", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseOperations", "ExpenseInformationId", "dbo.ExpenseOperationInfoes");
            DropForeignKey("dbo.ExpenseOperationInfoes", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ExpenseOperationInfoes", "BranchId", "dbo.Branches");
            DropIndex("dbo.ExpenseOperations", new[] { "ExpenseInformationId" });
            DropIndex("dbo.ExpenseOperations", new[] { "ItemId" });
            DropIndex("dbo.ExpenseOperationInfoes", new[] { "Employee_Id" });
            DropIndex("dbo.ExpenseOperationInfoes", new[] { "BranchId" });
            DropTable("dbo.ExpenseOperations");
            DropTable("dbo.ExpenseOperationInfoes");
        }
    }
}
