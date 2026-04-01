using System.ComponentModel.DataAnnotations;
namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Единицы измерения для складского учета товаров
    /// </summary>
    public enum MeasurementUnits
    {
        [Display(Name = "шт")]
        Piece = 1,

        [Display(Name = "мл")]
        Milliliter = 2,

        [Display(Name = "г")]
        Gram = 3
    }
}
