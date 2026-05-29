using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Хранит текущие курсы валют к рублю
    /// </summary>
    public class CurrencyRates
    {
        /// <summary>
        /// Код валюты (USD, EUR и т.д.) — первичный ключ
        /// </summary>
        [Key]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Текущий курс к рублю
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Дата и время последнего обновления курса
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Товары, закупленные по данной валюте
        /// </summary>
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}