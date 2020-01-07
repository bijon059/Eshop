namespace E_Shop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaddingUser : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserCategories", t => t.UserCategoryId, cascadeDelete: true)
                .Index(t => t.UserCategoryId);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories");
            DropIndex("dbo.Users", new[] { "UserCategoryId" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.Users");
        }
    }
}
