using System;

namespace Warehouse_cosmetics_shope.Helpers
{
    /// <summary>
    /// Вспомогательный класс для отображения категории с полным путём
    /// </summary>
    public class CategoryPath
    {
        public Guid CategoryID { get; set; }
        public string FullPath { get; set; }
    }
}
