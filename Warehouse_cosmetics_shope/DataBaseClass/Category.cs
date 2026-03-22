using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    /// <summary>
    /// Представляет категорию товаров на складе
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор категории
        /// </summary>
        [Key]
        public Guid CategoryID { get; set; }
        /// <summary>
        /// Наименование категории
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Идентификатор родительской категории
        /// Если значение null, категория считается корневой
        public Guid? ParentID { get; set; }// Guid — это значимый тип, он не может быть null. Значит, у каждой категории обязательно должен быть родитель. Но у главных категорий его нет
        /// <summary>
        /// Навигационное свойство для доступа к родительской категории
        /// </summary>
        [ForeignKey("ParentID")]
        public virtual Category Parent { get; set; }
        /// <summary>
        /// Коллекция дочерних подкатегорий
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        /// <summary>
        /// Список всех товаров, которые относятся напрямую к данной категории
        /// </summary>
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
