namespace Warehouse_cosmetics_shope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyAndCheckHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyRates",
                c => new
                    {
                        CurrencyCode = c.String(nullable: false, maxLength: 128),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyCode);
            
            CreateTable(
                "dbo.CheckHistories",
                c => new
                    {
                        HistoryID = c.Guid(nullable: false),
                        ClientID = c.Guid(nullable: false),
                        CheckDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.HistoryID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
            AddColumn("dbo.Items", "IsFragile", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "CellNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "CurrencyCode", c => c.String(maxLength: 128));
            AddColumn("dbo.Clients", "INN", c => c.String());
            AddColumn("dbo.Clients", "Region", c => c.String());
            CreateIndex("dbo.Items", "CurrencyCode");
            AddForeignKey("dbo.Items", "CurrencyCode", "dbo.CurrencyRates", "CurrencyCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckHistories", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Items", "CurrencyCode", "dbo.CurrencyRates");
            DropIndex("dbo.CheckHistories", new[] { "ClientID" });
            DropIndex("dbo.Items", new[] { "CurrencyCode" });
            DropColumn("dbo.Clients", "Region");
            DropColumn("dbo.Clients", "INN");
            DropColumn("dbo.Items", "CurrencyCode");
            DropColumn("dbo.Items", "CellNumber");
            DropColumn("dbo.Items", "IsFragile");
            DropTable("dbo.CheckHistories");
            DropTable("dbo.CurrencyRates");
        }
    }
}
