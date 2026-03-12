using System;
using System.Collections.Generic;
namespace Warehouse_cosmetics_shope.DataBaseClass
{
    internal class Category
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentID { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
