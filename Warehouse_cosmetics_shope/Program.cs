using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (WarehouseContext db = new WarehouseContext())
            {
                // создаем пользователя
                User user = new User
                {
                    UserID = Guid.NewGuid(),
                    Surname = "Иванов",
                    Name = "Иван",
                    Patronymic = "Иванович",
                    Password = "1234",
                    Role = Roles.Админ
                };
                db.Users.Add(user);
            }
            Console.ReadLine();
        }
    } 
}
