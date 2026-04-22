using System;
using Warehouse_cosmetics_shope.Enum;

namespace Warehouse_cosmetics_shope.Helpers
{
    public class ShipmentItem
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductNumber { get; set; }
        public string CategoryName { get; set; }
        public int StockQuantity { get; set; }
        public int Quantity { get; set; }
        public string ClientName { get; set; }
        public ClientTypes ClientType { get; set; }
    }
}
