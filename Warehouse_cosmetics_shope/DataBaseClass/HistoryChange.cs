using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Представляет запись в журнале истории изменений товаров
    /// Используется для аудита операций: создание, обновление, удаление
    /// </summary>
    public class HistoryChange
    {
        /// <summary>
        /// Уникальный идентификатор записи истории
        /// </summary>
        [Key]
        public Guid HistoryID { get; set; }

        /// <summary>
        /// ID товара, с которым произведено действие
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// ID пользователя, выполнившего действие
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Тип действия: "Create", "Update", "Delete"
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Дополнительное описание действия
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Дата и время выполнения действия
        /// </summary>
        public DateTime ActionDate { get; set; }

        /// <summary>
        /// Навигационное свойство: пользователь, выполнивший действие
        /// </summary>
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}