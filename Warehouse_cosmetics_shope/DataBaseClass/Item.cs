using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class Item
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public MeasurementUnits Units { get; set; }
        public int ExpDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<ShipmentComposition> ShipmentCompositions { get; set; } = new List<ShipmentComposition>();
    }
}
