namespace Warehouse_cosmetics_shope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseRateToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "PurchaseRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "PurchaseRate");
        }
    }
}
