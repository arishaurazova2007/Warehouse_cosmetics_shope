using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Представляет строку состава отгрузки 
    /// Описывает конкретный товар и его количество
    public class ShipmentComposition
    {
        /// <summary>
        /// Уникальный идентификатор строки состава
        /// </summary>
        [Key]
        public int CompositionID { get; set; }
        /// <summary>
        /// Идентификатор родительского документа отгрузки
        /// </summary>
        public Guid ShipmentID { get; set; }
        /// <summary>
        /// Идентификатор отгружаемого товара
        /// </summary>
        public Guid ProductID { get; set; }
        /// <summary>
        /// Количество единиц данного товара
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Навигационное свойство для доступа к заголовку отгрузки
        /// </summary>
        [ForeignKey("ShipmentID")]
        public virtual Shipment Shipment { get; set; }
        /// <summary>
        /// Навигационное свойство для доступа к подробным данным отгружаемого товара
        /// </summary>
        [ForeignKey("ProductID")]
        public virtual Item Product { get; set; }
    }
}
