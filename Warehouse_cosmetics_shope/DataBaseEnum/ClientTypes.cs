using System.ComponentModel.DataAnnotations;
namespace Warehouse_cosmetics_shope.Enum
{
    /// <summary>
    /// Категории клиентов для ведения документооборота и учета отгрузок
    /// </summary>
    public enum ClientTypes
    {
        [Display(Name = "Юридическое лицо")]
        LegalEntity = 1,

        [Display(Name = "Индивидуальный предприниматель")]
        IndividualEntrepreneur = 2,

        [Display(Name = "Физическое лицо")]
        Individual = 3
    }
}
