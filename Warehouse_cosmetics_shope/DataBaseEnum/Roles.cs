using System.ComponentModel.DataAnnotations;
namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Уровни доступа пользователей к функциям системы управления складом
    /// </summary>
    public enum Roles
    {
        [Display(Name = "Администратор")]
        Admin = 1,

        [Display(Name = "Кладовщик")]
        Storekeeper = 2
    }
}
