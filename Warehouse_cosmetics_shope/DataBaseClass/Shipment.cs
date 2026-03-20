using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class Shipment
    {
        [Key]
        public Guid ShipmentID { get; set; }
        public Guid ClientID { get; set; }
        public Guid UserID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<ShipmentComposition> ShipmentCompositions { get; set; } = new List<ShipmentComposition>();
    }
}
