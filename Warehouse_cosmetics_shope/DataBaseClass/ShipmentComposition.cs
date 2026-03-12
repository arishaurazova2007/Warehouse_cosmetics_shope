using System;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class ShipmentComposition
    {
        public int CompositionID { get; set; }
        public Guid ShipmentID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual Item Item { get; set; }
    }
}
