using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    internal class Client
    {
        [Key]
        public Guid ClientID { get; set; }
        public ClientTypes ClientType { get; set; }
        public string ClientName { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
    }
}
