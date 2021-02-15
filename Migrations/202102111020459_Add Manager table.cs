namespace EFCodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManagertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            AddColumn("dbo.Employees", "Manager_ManagerId", c => c.Int());
            CreateIndex("dbo.Employees", "Manager_ManagerId");
            AddForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers", "ManagerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers");
            DropIndex("dbo.Employees", new[] { "Manager_ManagerId" });
            DropColumn("dbo.Employees", "Manager_ManagerId");
            DropTable("dbo.Managers");
        }
    }
}
