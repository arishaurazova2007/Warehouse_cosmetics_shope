namespace Warehouse_cosmetics_shope.Migrations
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
                        CategoryID = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        ParentID = c.Guid(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Categories", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ProductID = c.Guid(nullable: false),
                        ProductName = c.String(),
                        CategoryID = c.Guid(nullable: false),
                        Units = c.Int(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ShipmentCompositions",
                c => new
                    {
                        CompositionID = c.Int(nullable: false, identity: true),
                        ShipmentID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompositionID)
                .ForeignKey("dbo.Items", t => t.ProductID)
                .ForeignKey("dbo.Shipments", t => t.ShipmentID, cascadeDelete: true)
                .Index(t => t.ShipmentID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShipmentID = c.Guid(nullable: false),
                        ClientID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ClientID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Guid(nullable: false),
                        CType = c.Int(nullable: false),
                        ClientName = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropForeignKey("dbo.ShipmentCompositions", "ShipmentID", "dbo.Shipments");
            DropForeignKey("dbo.Shipments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Shipments", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.ShipmentCompositions", "ProductID", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Shipments", new[] { "UserID" });
            DropIndex("dbo.Shipments", new[] { "ClientID" });
            DropIndex("dbo.ShipmentCompositions", new[] { "ProductID" });
            DropIndex("dbo.ShipmentCompositions", new[] { "ShipmentID" });
            DropIndex("dbo.Items", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentCompositions");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
