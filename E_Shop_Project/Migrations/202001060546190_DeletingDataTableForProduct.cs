namespace E_Shop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingDataTableForProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories");
            DropIndex("dbo.Users", new[] { "UserCategoryId" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(),
                        ErrorloginAtempt = c.Short(nullable: false),
                        UserCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Users", "UserCategoryId");
            AddForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories", "Id", cascadeDelete: true);
        }
    }
}
