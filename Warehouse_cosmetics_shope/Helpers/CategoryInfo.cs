using System;
namespace Warehouse_cosmetics_shope.Helpers
{
    public class CategoryInfo
    {
        public Guid CategoryID { get; set; }
        public string DisplayName { get; set; }
        public Guid? ParentID { get; set; }
    }
}
