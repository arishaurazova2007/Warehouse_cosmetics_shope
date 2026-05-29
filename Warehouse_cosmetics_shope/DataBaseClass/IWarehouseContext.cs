using System;
using System.Data.Entity;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Интерфейс контекста данных.
    /// Формы зависят от этого интерфейса, а не от конкретного WarehouseContext.
    /// </summary>
    public interface IWarehouseContext : IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Shipment> Shipments { get; set; }
        DbSet<ShipmentComposition> ShipmentCompositions { get; set; }
        DbSet<CurrencyRates> CurrencyRates { get; set; }
        DbSet<CheckHistory> CheckHistory { get; set; }

        /// <summary>
        /// Сохраняет изменения в базу данных
        /// </summary>
        int SaveChanges();
    }
}