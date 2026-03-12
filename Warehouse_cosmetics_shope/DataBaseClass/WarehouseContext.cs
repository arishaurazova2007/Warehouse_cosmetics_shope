using System;
using System.Data.Entity;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class WarehouseContext : DbContext
    {
        public WarehouseContext() : base("WarehouseConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WarehouseContext>());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentComposition> ShipmentCompositions { get; set; }
    }
}
