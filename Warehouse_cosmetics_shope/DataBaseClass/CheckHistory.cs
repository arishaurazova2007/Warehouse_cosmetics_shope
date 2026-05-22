using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Журнал проверок контрагентов
    /// </summary>
    public class CheckHistory
    {
        /// <summary>
        /// Уникальный идентификатор записи проверки
        /// </summary>
        [Key]
        public Guid HistoryID { get; set; }

        /// <summary>
        /// Идентификатор проверяемого клиента
        /// </summary>
        public Guid ClientID { get; set; }

        /// <summary>
        /// Навигационное свойство клиента
        /// </summary>
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        /// <summary>
        /// Дата и время проведения проверки
        /// </summary>
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// Статус проверки ("Пройдена", "Отклонена")
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Подробности результата проверки
        /// </summary>
        public string Details { get; set; }
    }
}