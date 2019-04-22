namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employeee_model_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        BranchId = c.Int(nullable: false),
                        JoinningDate = c.String(),
                        ImagePath = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        ReferenceId = c.Int(),
                        EmergencyContact = c.String(),
                        NID = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
