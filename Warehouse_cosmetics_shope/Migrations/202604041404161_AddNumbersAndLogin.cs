namespace Warehouse_cosmetics_shope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumbersAndLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserLogin", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "UserNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserNumber", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "UserLogin");
        }
    }
}
