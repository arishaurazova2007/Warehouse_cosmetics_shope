using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (WarehouseContext db = new WarehouseContext())
            {
                db.Items.RemoveRange(db.Items);
                db.Categories.RemoveRange(db.Categories);
                db.Users.RemoveRange(db.Users);
                db.SaveChanges();

                db.Users.AddRange(new List<User>
                {
                    new User
                    { 
                        UserID = Guid.NewGuid(),
                        Surname = "Иванова",
                        Name = "Татьяна",
                        Patronymic = "Константиновна",
                        Password = "16Kl7SDt!",
                        Role = Roles.Админ
                    },
                    new User 
                    {
                        UserID = Guid.NewGuid(),
                        Surname = "Кузнецов",
                        Name = "Антон",
                        Patronymic = "Юрьевич",
                        Password = "Hy56E2))L3",
                        Role = Roles.Админ
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        Surname = "Смирнов",
                        Name = "Андрей",
                        Patronymic = "Павлович",
                        Password = "8d2Tb%Q245",
                        Role = Roles.Админ
                    }
                });

                var catPerfume = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Парфюмерия" };
                var catCosmetics = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Косметика" };
                db.Categories.AddRange(new List<Category> { catPerfume, catCosmetics });

                var catFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Женская парфюмерия", ParentID = catPerfume.CategoryID };
                var catMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Мужская парфюмерия", ParentID = catPerfume.CategoryID };
                var catDecor = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Декоративная", ParentID = catCosmetics.CategoryID };
                var catCare = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Уходовая", ParentID = catCosmetics.CategoryID };
                db.Categories.AddRange(new List<Category> { catFemale, catMale, catDecor, catCare });

                var subCatDuhyFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Духи женские", ParentID = catFemale.CategoryID };
                var subCatDuhyMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Духи мужские", ParentID = catMale.CategoryID };
                var subCatWaterFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Парфюмерная вода женская", ParentID = catFemale.CategoryID };
                var subCatWaterMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Туалетная вода мужская", ParentID = catMale.CategoryID };
                db.Categories.AddRange(new List<Category> { subCatDuhyFemale, subCatDuhyMale, subCatWaterFemale, subCatWaterMale });

                db.SaveChanges();

                
                db.Items.AddRange(new List<Item>
                {
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "Chanel №5 (50 мл)",
                        CategoryID = catFemale.CategoryID, // Привязка к созданной категории
                        Price = 12100,
                        Quantity = 14,
                        Units = MeasurementUnits.Шт,
                        ExpDate = new DateTime(2028, 09, 15)
                    },
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "Librederm Гиалуроновый крем, 50 мл",
                        CategoryID = catCare.CategoryID,
                        Price = 810,
                        Quantity = 145,
                        Units = MeasurementUnits.Шт,
                        ExpDate = new DateTime(2028, 03, 16)
                    },
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "KRYGINA Блеск для губ LIP MAXIMALIST",
                        CategoryID = catDecor.CategoryID,
                        Price = 1050,
                        Quantity = 57,
                        Units = MeasurementUnits.Шт, 
                        ExpDate = new DateTime(2028, 05, 18)
                    }
                });

                db.SaveChanges();
                Console.WriteLine("База данных успешно заполнена данными из таблицы!");
            }
            Console.ReadLine();
        }
    } 
}
