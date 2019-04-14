namespace DMACC.CIS174.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingUpTheDataModelForAddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "Address_AddressId" });
            AddColumn("dbo.Addresses", "Student_StudentId", c => c.Guid());
            CreateIndex("dbo.Addresses", "Student_StudentId");
            AddForeignKey("dbo.Addresses", "Student_StudentId", "dbo.Students", "StudentId");
            DropColumn("dbo.Students", "Address_AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Address_AddressId", c => c.Guid());
            DropForeignKey("dbo.Addresses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Addresses", new[] { "Student_StudentId" });
            DropColumn("dbo.Addresses", "Student_StudentId");
            CreateIndex("dbo.Students", "Address_AddressId");
            AddForeignKey("dbo.Students", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
