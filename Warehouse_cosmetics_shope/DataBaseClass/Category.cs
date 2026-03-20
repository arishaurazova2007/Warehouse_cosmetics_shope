using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentID { get; set; }// Guid — это значимый тип, он не может быть null. Значит, у каждой категории обязательно должен быть родитель. Но у главных категорий его нет!
        [ForeignKey("ParentID")]
        public virtual Category Parent {  get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
