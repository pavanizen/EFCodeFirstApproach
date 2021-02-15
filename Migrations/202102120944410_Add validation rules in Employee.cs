namespace EFCodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddvalidationrulesinEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmpName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmpName", c => c.String());
        }
    }
}
