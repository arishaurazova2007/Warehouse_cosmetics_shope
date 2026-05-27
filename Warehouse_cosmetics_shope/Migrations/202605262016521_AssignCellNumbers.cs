namespace Warehouse_cosmetics_shope.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AssignCellNumbers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                WITH numbered AS (
                    SELECT ProductID, 
                           ROW_NUMBER() OVER (ORDER BY ProductNumber) AS rn
                    FROM Items 
                    WHERE CellNumber = 0
                )
                UPDATE Items 
                SET CellNumber = numbered.rn
                FROM numbered 
                WHERE Items.ProductID = numbered.ProductID
            ");
        }

        public override void Down()
        {
        }
    }
}