namespace Jude.ES365.ShopApp.DatAcc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fuiy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        ShortName = c.String(maxLength: 200, unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Description = c.String(unicode: false),
                        IsStockAvailable = c.Boolean(),
                        IsOnSale = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        SalePrice = c.Double(),
                        NumberOfViewsByCustomer = c.Int(nullable: false),
                        Rating = c.Decimal(precision: 12, scale: 2),
                        CategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CustomerId = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        IsOrderCompleted = c.Boolean(nullable: false),
                        IsOrderCancelled = c.Boolean(nullable: false),
                        TotalPayableAmout = c.Double(nullable: false),
                        NumberOfItemsPurchased = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 200, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 200, unicode: false),
                        Gender = c.Boolean(),
                        Phone = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Address = c.String(unicode: false),
                        IsAccountValid = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductPhoto",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Filename = c.String(nullable: false, unicode: false),
                        UploadedOn = c.DateTime(nullable: false),
                        ProductId = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductPhoto", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.ProductPhoto", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.ProductPhoto");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
