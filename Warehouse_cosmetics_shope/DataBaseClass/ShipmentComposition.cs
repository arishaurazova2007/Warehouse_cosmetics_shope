using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class ShipmentComposition
    {
        [Key]
        public int CompositionID { get; set; }
        public Guid ShipmentID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ShipmentID")]
        public virtual Shipment Shipment { get; set; }
        [ForeignKey("ProductID")]
        public virtual Item Product { get; set; }
    }
}
