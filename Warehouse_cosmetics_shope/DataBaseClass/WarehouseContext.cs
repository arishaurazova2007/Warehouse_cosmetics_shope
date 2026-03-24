using System;
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
        /// <summary> 
        /// Таблица клиентов склада
        /// </summary>
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// Таблица зарегистрированных пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Таблица товаров, доступных на складе
        /// </summary>
        public DbSet<Item> Items { get; set; }
        /// <summary>
        /// Таблица категорий товаров
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary> 
        /// Журнал документов отгрузки
        /// </summary>
        public DbSet<Shipment> Shipments { get; set; }
        /// <summary>
        /// Детализированный состав каждой отгрузки
        /// </summary>
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
