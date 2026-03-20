using System;
using System.Data.Entity;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class WarehouseContext : DbContext
    {
        public WarehouseContext() : base("DBConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WarehouseContext>());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentComposition> ShipmentCompositions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка самоссылающейся связи для категорий
            modelBuilder.Entity<Category>()
                .HasOptional(c => c.Parent)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentID)
                .WillCascadeOnDelete(false); // Отключаем каскад, чтобы не удалить всё дерево целиком

            // Настройка связи Состава с Отгрузкой
            modelBuilder.Entity<ShipmentComposition>()
                .HasRequired(sc => sc.Shipment)
                .WithMany(s => s.ShipmentCompositions)
                .HasForeignKey(sc => sc.ShipmentID)
                .WillCascadeOnDelete(true); // При удалении отгрузки удаляем её строки

            // Настройка связи Состава с Товаром
            modelBuilder.Entity<ShipmentComposition>()
                .HasRequired(sc => sc.Product)
                .WithMany(p => p.ShipmentCompositions)
                .HasForeignKey(sc => sc.ProductID)
                .WillCascadeOnDelete(false); // Не удаляем товар при удалении отгрузки!

            base.OnModelCreating(modelBuilder);
        }
    }
}
