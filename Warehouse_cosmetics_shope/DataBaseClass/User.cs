using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Warehouse_cosmetics_shope.DataBaseClass;
namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Представляет учетную запись сотрудника склада косметики
    /// Используется для авторизации и отслеживания ответственных лиц за отгрузки
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        [Key]
        public Guid UserID { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество сотрудника (при наличии)
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Пароль для входа в систему
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Роль пользователя в системе
        /// </summary>
        public Roles Role { get; set; }
        /// <summary>
        /// Коллекция отгрузок, оформленных данным пользователем
        /// Позволяет отслеживать историю операций конкретного сотрудника
        /// </summary>
        public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
    }
}
