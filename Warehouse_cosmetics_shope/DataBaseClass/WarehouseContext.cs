using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Основной контекст данных приложения для взаимодействия с базой данных через Entity Framework
    /// Обеспечивает доступ к таблицам клиентов, пользователей, товаров и документов отгрузки
    /// </summary>
    public class WarehouseContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр контекста, используя строку подключения
        /// </summary>
        public WarehouseContext() : base("WarehouseContext")
        {
            Database.SetInitializer<WarehouseContext>(null);
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
        /// <summary>
        /// Журнал истории изменений товаров
        /// </summary>
        public DbSet<HistoryChange> HistoryChanges { get; set; }
    }
}
