using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Представляет клиента, участвующего в операциях отгрузки со склада
    /// Класс хранит информацию о типе клиента и историю его заказов
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        [Key]
        public Guid ClientID { get; set; }
        /// <summary>
        /// Категория клиента
        /// Определяется через перечисление ClientTypes
        /// </summary>
        public ClientTypes CType { get; set; }
        /// <summary>
        /// Наименование организации или полное имя частного лица
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// Коллекция связанных отгрузок
        /// Позволяет отслеживать все товары, когда-либо отправленные данному клиенту
        /// </summary>
        public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
    }
}
