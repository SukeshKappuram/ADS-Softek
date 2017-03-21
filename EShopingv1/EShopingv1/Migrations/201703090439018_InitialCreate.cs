namespace EShopingv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        SerialNumber = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ExpieryDate = c.DateTime(nullable: false),
                        ManufactureDate = c.DateTime(nullable: false),
                        Size = c.String(nullable: false, maxLength: 10),
                        Color = c.String(nullable: false, maxLength: 10),
                        sellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNumber)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.sellerId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.sellerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        manufactureName = c.String(nullable: false, maxLength: 30),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false, maxLength: 20),
                        middleName = c.String(maxLength: 20),
                        lastName = c.String(nullable: false, maxLength: 20),
                        mailId = c.String(nullable: false),
                        phoneNumber = c.String(nullable: false),
                        OutletName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        roleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 100),
                        State = c.String(nullable: false),
                        Pincode = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SpecialOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferName = c.String(nullable: false, maxLength: 20),
                        Discount = c.Single(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        MinQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductDetails", "sellerId", "dbo.Users");
            DropForeignKey("dbo.Roles", "userId", "dbo.Users");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShippingAddresses", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "userId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductDetails", new[] { "sellerId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropTable("dbo.SpecialOffers");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Categories");
        }
    }
}
