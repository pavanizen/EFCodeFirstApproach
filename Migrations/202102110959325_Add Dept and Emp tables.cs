namespace EFCodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeptandEmptables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        Salary = c.Double(nullable: false),
                        Department_DeptId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
               
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .Index(t => t.Department_DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DeptId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
