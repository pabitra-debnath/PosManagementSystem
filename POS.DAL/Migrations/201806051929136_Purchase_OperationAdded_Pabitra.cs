namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_OperationAdded_Pabitra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            CreateTable(
                "dbo.PurchaseOperationInfoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseNo = c.String(nullable: false),
                        BranchId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        SupplierId = c.Long(nullable: false),
                        Remarks = c.String(),
                        TotalAmount = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Parties", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.SupplierId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.PurchaseOperations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Quantity = c.Long(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        LineTotal = c.Double(nullable: false),
                        Date = c.DateTime(),
                        PurchaseInformationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOperationInfoes", t => t.PurchaseInformationId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.PurchaseInformationId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BranchId = c.Long(nullable: false),
                        ItemId = c.Long(nullable: false),
                        StockQuantity = c.Long(nullable: false),
                        AveragePrice = c.Double(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.ItemId);
            
            DropTable("dbo.Inventories");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        OrganizationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        TotalAmmmount = c.Double(nullable: false),
                        DueAmmount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Stocks", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Stocks", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.PurchaseOperationInfoes", "SupplierId", "dbo.Parties");
            DropForeignKey("dbo.PurchaseOperations", "PurchaseInformationId", "dbo.PurchaseOperationInfoes");
            DropForeignKey("dbo.PurchaseOperations", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PurchaseOperationInfoes", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.PurchaseOperationInfoes", "BranchId", "dbo.Branches");
            DropIndex("dbo.Stocks", new[] { "ItemId" });
            DropIndex("dbo.Stocks", new[] { "BranchId" });
            DropIndex("dbo.PurchaseOperations", new[] { "PurchaseInformationId" });
            DropIndex("dbo.PurchaseOperations", new[] { "ItemId" });
            DropIndex("dbo.PurchaseOperationInfoes", new[] { "Employee_Id" });
            DropIndex("dbo.PurchaseOperationInfoes", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOperationInfoes", new[] { "BranchId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.PurchaseOperations");
            DropTable("dbo.PurchaseOperationInfoes");
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
        }
    }
}
