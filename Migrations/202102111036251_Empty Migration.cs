namespace EFCodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Departments values('Technical')");
            Sql("Insert into Departments values('Finance')");
            

        }
        
        public override void Down()
        {

        }
    }
}
