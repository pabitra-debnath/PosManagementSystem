namespace POS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_JoiningDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "JoiningDate", c => c.String());
            DropColumn("dbo.Employees", "JoinningDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "JoinningDate", c => c.String());
            DropColumn("dbo.Employees", "JoiningDate");
        }
    }
}
