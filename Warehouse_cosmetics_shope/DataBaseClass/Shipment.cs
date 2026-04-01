using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Представляет документ отгрузки товаров со склада
    /// Является заголовком накладной, связывающим дату операции, клиента и сотрудника
    /// </summary>
    public class Shipment
    {
        /// <summary>
        /// Уникальный идентификатор отгрузки
        /// </summary>
        [Key]
        public Guid ShipmentID { get; set; }

        /// <summary>
        /// Идентификатор клиента, получающего товар
        /// </summary>
        public Guid ClientID { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, оформившего отгрузку
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Дата и время совершения операции отгрузки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Навигационное свойство для доступа к данным клиента
        /// </summary>
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        /// <summary>
        /// Навигационное свойство для доступа к данным сотрудника, создавшего запись
        /// </summary>
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        /// <summary>
        /// Коллекция строк состава отгрузки
        /// Содержит перечень товаров и их количество
        /// </summary>
        public virtual ICollection<ShipmentComposition> ShipmentCompositions { get; set; } = new List<ShipmentComposition>();
    }
}