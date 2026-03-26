using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Представляет товарную позицию на складе косметики и парфюмерии
    /// Хранит данные о стоимости, остатках, сроках годности и единицах измерения
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
        [Key]
        public Guid ProductID { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Идентификатор категории, к которой привязан товар
        /// </summary>
        public Guid CategoryID { get; set; }
        /// <summary>
        /// Навигационное свойство для доступа к объекту категории данного товара
        /// </summary>
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        /// <summary>
        /// Единица измерения
        /// Использует перечисление MeasurementUnits
        /// </summary>
        public MeasurementUnits Units { get; set; }
        /// <summary>
        /// Срок годности товара
        /// </summary>
        public DateTime ExpDate { get; set; }
        /// <summary>
        /// Цена за единицу товара.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Текущий фактический остаток товара на складе
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Коллекция записей в составах отгрузок
        /// Связывает товар с конкретными накладными через таблицу ShipmentComposition
        /// </summary>
        public virtual ICollection<ShipmentComposition> ShipmentCompositions { get; set; } = new List<ShipmentComposition>();
    }
}
