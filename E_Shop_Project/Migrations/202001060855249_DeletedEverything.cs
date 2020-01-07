namespace E_Shop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedEverything : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories");
            DropForeignKey("dbo.Users", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Users", new[] { "UserCategoryId" });
            DropIndex("dbo.Users", new[] { "Product_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Users");
            DropTable("dbo.UserCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        AddedDate = c.DateTime(),
                        AddedBy = c.String(),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Users", "Product_Id");
            CreateIndex("dbo.Users", "UserCategoryId");
            CreateIndex("dbo.Products", "ProductCategory_Id");
            AddForeignKey("dbo.Users", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Users", "UserCategoryId", "dbo.UserCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories", "Id");
        }
    }
}
