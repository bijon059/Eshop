namespace E_Shop_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiallyProductAdded : DbMigration
    {
        public override void Up()
        {
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
                        CategoryId = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Product_Id", c => c.Int());
            CreateIndex("dbo.Users", "Product_Id");
            AddForeignKey("dbo.Users", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropIndex("dbo.Users", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropColumn("dbo.Users", "Product_Id");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
        }
    }
}
