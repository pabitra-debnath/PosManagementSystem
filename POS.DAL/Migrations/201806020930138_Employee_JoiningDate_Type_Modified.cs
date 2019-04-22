namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_JoiningDate_Type_Modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "JoiningDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "JoiningDate", c => c.String());
        }
    }
}
