using System;
using System.Collections.Generic;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class Shipment
    {
        public Guid ShipmentID { get; set; }
        public Guid ClientID { get; set; }
        public Guid UserID { get; set; }
        public DateTime Date { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ShipmentComposition> Compositions { get; set; } = new List<ShipmentComposition>();
    }
}
