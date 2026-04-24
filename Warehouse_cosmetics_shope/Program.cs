using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Warehouse_cosmetics_shope.DataBaseClass;
using Warehouse_cosmetics_shope.Enum;

namespace Warehouse_cosmetics_shope
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                Log.Information("Приложение запущено");
                InitializeDatabase();

                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Произошла ошибка!");
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void InitializeDatabase()
        {
            using (var db = new WarehouseContext())
            {
                // Проверяем, есть ли уже данные
                if (db.Users.Any())
                {
                    Log.Information("База данных уже содержит данные, инициализация пропущена.");
                    return;
                }

                Log.Information("Начинаем заполнение базы данных...");

                // Добавляем пользователей
                db.Users.AddRange(new List<User>
                {
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin ="latDina001",
                        Surname = "Латыпова",
                        Name = "Дина",
                        Patronymic = "Сергеевна",
                        Password = BCrypt.Net.BCrypt.HashPassword("16Kl7SDt!"),
                        Role = Roles.Admin
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin ="kuznets008",
                        Surname = "Кузнецов",
                        Name = "Антон",
                        Patronymic = "Юрьевич",
                        Password = BCrypt.Net.BCrypt.HashPassword("Hy56E2))L3"),
                        Role = Roles.Admin
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin ="volkovaeliz06admin",
                        Surname = "Волкова",
                        Name = "Елизавета",
                        Patronymic = "Александровна",
                        Password = BCrypt.Net.BCrypt.HashPassword("QHTIr0841"),
                        Role = Roles.Admin
                    }
                });
                db.SaveChanges();

                // Добавляем категории
                var catPerfume = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Парфюмерия" };
                var catCosmetics = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Косметика" };
                db.Categories.AddRange(new List<Category> { catPerfume, catCosmetics });

                var catFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Женская парфюмерия", ParentID = catPerfume.CategoryID };
                var catMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Мужская парфюмерия", ParentID = catPerfume.CategoryID };
                var catDecor = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Декоративная косметика", ParentID = catCosmetics.CategoryID };
                var catCare = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Уходовая косметика", ParentID = catCosmetics.CategoryID };
                db.Categories.AddRange(new List<Category> { catFemale, catMale, catDecor, catCare });

                var subCatDuhyFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Духи женские", ParentID = catFemale.CategoryID };
                var subCatDuhyMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Духи мужские", ParentID = catMale.CategoryID };
                var subCatWaterPerfumFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Парфюмерная вода женская", ParentID = catFemale.CategoryID };
                var subCatWaterPerfumMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Парфюмерная вода мужская", ParentID = catMale.CategoryID };
                var subCatWaterFemale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Туалетная вода женская", ParentID = catFemale.CategoryID };
                var subCatWaterMale = new Category { CategoryID = Guid.NewGuid(), CategoryName = "Туалетная вода мужская", ParentID = catMale.CategoryID };

                db.Categories.AddRange(new List<Category> {
                    subCatDuhyFemale, subCatDuhyMale, subCatWaterFemale, subCatWaterMale,
                    subCatWaterPerfumFemale, subCatWaterPerfumMale
                });
                db.SaveChanges();

                // Добавляем товары
                db.Items.AddRange(new List<Item>
                {
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "Chanel №5 (50 мл)",
                        CategoryID = subCatDuhyFemale.CategoryID,
                        PurPrice = 12100,
                        SellPrice = 13800,
                        Quantity = 14,
                        Units = MeasurementUnits.Piece,
                        ManufDate = new DateTime(2025,12,02),
                        ExpDate = new DateTime(2028, 12, 02)
                    },
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "Librederm Гиалуроновый крем, 50 мл",
                        CategoryID = catCare.CategoryID,
                        PurPrice = 810,
                        SellPrice = 890,
                        Quantity = 145,
                        Units = MeasurementUnits.Piece,
                        ManufDate = new DateTime(2026,02,02),
                        ExpDate = new DateTime(2028, 03, 16)
                    },
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "KRYGINA Блеск для губ LIP MAXIMALIST 09",
                        CategoryID = catDecor.CategoryID,
                        PurPrice = 1050,
                        SellPrice = 1210,
                        Quantity = 57,
                        Units = MeasurementUnits.Piece,
                        ManufDate = new DateTime(2024,05,18),
                        ExpDate = new DateTime(2026, 05, 18)
                    },
                    new Item
                    {
                        ProductID = Guid.NewGuid(),
                        ProductName = "MAKE UP REVOLUTION Палетка теней для век ICON",
                        CategoryID = catDecor.CategoryID,
                        PurPrice = 1220,
                        SellPrice = 1450,
                        Quantity = 10,
                        Units = MeasurementUnits.Piece,
                        ManufDate = new DateTime(2023,06,09),
                        ExpDate = new DateTime(2026, 06, 09)
                    }
                });

                db.SaveChanges();
                Log.Information("База данных успешно заполнена");
            }
        }
    }
}