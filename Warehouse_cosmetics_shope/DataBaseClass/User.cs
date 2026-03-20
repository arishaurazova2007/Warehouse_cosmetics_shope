using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    internal class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        //public virtual ICollection<Shipment> Shipment { get; set; } = new List<Shipment>();
    }
}
