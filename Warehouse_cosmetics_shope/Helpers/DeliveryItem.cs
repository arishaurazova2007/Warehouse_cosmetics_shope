using System;

namespace Warehouse_cosmetics_shope.Helpers
{
    public class DeliveryItem
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal PurPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufDate { get; set; }
        public DateTime ExpDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal PurechaseRate { get; set; }
    }
}
