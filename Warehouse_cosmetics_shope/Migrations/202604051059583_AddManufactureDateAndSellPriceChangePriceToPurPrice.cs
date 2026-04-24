namespace Warehouse_cosmetics_shope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManufactureDateAndSellPriceChangePriceToPurPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ManufDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "PurPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Items", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "UserLogin", c => c.String());
            DropColumn("dbo.Items", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "UserLogin", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "SellPrice");
            DropColumn("dbo.Items", "PurPrice");
            DropColumn("dbo.Items", "ManufDate");
        }
    }
}
