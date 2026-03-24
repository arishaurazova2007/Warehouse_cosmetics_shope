namespace Warehouse_cosmetics_shope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixIdTypeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ExpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ExpDate", c => c.Int(nullable: false));
        }
    }
}
