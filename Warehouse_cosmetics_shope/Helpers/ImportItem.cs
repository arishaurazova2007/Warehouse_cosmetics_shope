using System;
namespace Warehouse_cosmetics_shope.Helpers
{
    public class ImportItem
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal PurPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufDate { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
