using System.Data.Entity;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Основной контекст данных приложения для взаимодействия с базой данных через Entity Framework
    /// Обеспечивает доступ к таблицам клиентов, пользователей, товаров и документов отгрузки
    /// </summary>
    public class WarehouseContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр контекста, используя строку подключения "DBConnection"
        /// </summary>
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
                .WillCascadeOnDelete(false);

            // Настройка связи Item с Category
            modelBuilder.Entity<Item>()
                .HasRequired(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryID)
                .WillCascadeOnDelete(false);

            // Настройка связи Shipment с Client
            modelBuilder.Entity<Shipment>()
                .HasRequired(s => s.Client)
                .WithMany(c => c.Shipments)
                .HasForeignKey(s => s.ClientID)
                .WillCascadeOnDelete(false);

            // Настройка связи Shipment с User
            modelBuilder.Entity<Shipment>()
                .HasRequired(s => s.User)
                .WithMany(u => u.Shipments)
                .HasForeignKey(s => s.UserID)
                .WillCascadeOnDelete(false);

            // Настройка связи ShipmentComposition с Shipment
            modelBuilder.Entity<ShipmentComposition>()
                .HasRequired(sc => sc.Shipment)
                .WithMany(s => s.ShipmentCompositions)
                .HasForeignKey(sc => sc.ShipmentID)
                .WillCascadeOnDelete(true);

            // Настройка связи ShipmentComposition с Item
            modelBuilder.Entity<ShipmentComposition>()
                .HasRequired(sc => sc.Product)
                .WithMany(p => p.ShipmentCompositions)
                .HasForeignKey(sc => sc.ProductID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
