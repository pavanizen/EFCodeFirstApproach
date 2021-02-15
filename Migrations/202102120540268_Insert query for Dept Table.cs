namespace EFCodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertqueryforDeptTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers");
            DropIndex("dbo.Employees", new[] { "Department_DeptId" });
            DropIndex("dbo.Employees", new[] { "Manager_ManagerId" });
            RenameColumn(table: "dbo.Employees", name: "Department_DeptId", newName: "DeptId");
            RenameColumn(table: "dbo.Employees", name: "Manager_ManagerId", newName: "ManagerId");
            AlterColumn("dbo.Employees", "DeptId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DeptId");
            CreateIndex("dbo.Employees", "ManagerId");
            AddForeignKey("dbo.Employees", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "ManagerId", "dbo.Managers", "ManagerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            AlterColumn("dbo.Employees", "ManagerId", c => c.Int());
            AlterColumn("dbo.Employees", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "ManagerId", newName: "Manager_ManagerId");
            RenameColumn(table: "dbo.Employees", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.Employees", "Manager_ManagerId");
            CreateIndex("dbo.Employees", "Department_DeptId");
            AddForeignKey("dbo.Employees", "Manager_ManagerId", "dbo.Managers", "ManagerId");
            AddForeignKey("dbo.Employees", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
