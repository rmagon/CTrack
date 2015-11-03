namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "companyid", c => c.Long());
            AddColumn("dbo.AspNetUsers", "departmentId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "departmentId");
            DropColumn("dbo.AspNetUsers", "companyid");
        }
    }
}
