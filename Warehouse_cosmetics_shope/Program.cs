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

                // Сначала инициализируем базу данных
                InitializeDatabase();

                // Потом запускаем форму
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

                Log.Information("Начинаем заполнение базы данных...");

                // Добавляем пользователей
                db.Users.AddRange(new List<User>
                {
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin = "latDina001",
                        Surname = "Латыпова",
                        Name = "Дина",
                        Patronymic = "Сергеевна",
                        Password = BCrypt.Net.BCrypt.HashPassword("16Kl7SDt!"),
                        Role = Roles.Admin
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin = "kuznets008",
                        Surname = "Кузнецов",
                        Name = "Антон",
                        Patronymic = "Юрьевич",
                        Password = BCrypt.Net.BCrypt.HashPassword("Hy56E2))L3"),
                        Role = Roles.Admin
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin = "volkovaeliz06admin",
                        Surname = "Волкова",
                        Name = "Елизавета",
                        Patronymic = "Александровна",
                        Password = BCrypt.Net.BCrypt.HashPassword("QHTIr0841"),
                        Role = Roles.Admin
                    },
                    new User
                    {
                        UserID = Guid.NewGuid(),
                        UserLogin = "volkovaeliz06",
                        Surname = "Волкова",
                        Name = "Елизавета",
                        Patronymic = "Александровна",
                        Password = BCrypt.Net.BCrypt.HashPassword("QHTIr0841"),
                        Role = Roles.Storekeeper
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
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 12, 02),
                    ExpDate = new DateTime(2028, 12, 02)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Dior J'adore (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 13500,
                    SellPrice = 15500,
                    Quantity = 8,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 01, 15),
                    ExpDate = new DateTime(2029, 01, 15)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Gucci Bloom (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 9800,
                    SellPrice = 11200,
                    Quantity = 12,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 10, 10),
                    ExpDate = new DateTime(2028, 10, 10)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Lancôme La Vie Est Belle (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 11200,
                    SellPrice = 12900,
                    Quantity = 6,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 02, 20),
                    ExpDate = new DateTime(2029, 02, 20)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Yves Saint Laurent Black Opium (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 11800,
                    SellPrice = 13500,
                    Quantity = 10,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 11, 05),
                    ExpDate = new DateTime(2028, 11, 05)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Марлен (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 12500,
                    SellPrice = 14200,
                    Quantity = 5,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 03, 10),
                    ExpDate = new DateTime(2029, 03, 10)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Цветочное настроение (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 4500,
                    SellPrice = 5200,
                    Quantity = 25,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 09, 15),
                    ExpDate = new DateTime(2028, 09, 15)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Восточная сказка (50 мл)",
                    CategoryID = subCatDuhyFemale.CategoryID,
                    PurPrice = 4800,
                    SellPrice = 5500,
                    Quantity = 18,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 08, 20),
                    ExpDate = new DateTime(2028, 08, 20)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Chanel Chance Eau Tendre (100 мл)",
                    CategoryID = subCatWaterFemale.CategoryID,
                    PurPrice = 8900,
                    SellPrice = 10200,
                    Quantity = 20,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 07, 01),
                    ExpDate = new DateTime(2028, 07, 01)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Versace Bright Crystal (90 мл)",
                    CategoryID = subCatWaterFemale.CategoryID,
                    PurPrice = 7600,
                    SellPrice = 8700,
                    Quantity = 15,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 06, 15),
                    ExpDate = new DateTime(2028, 06, 15)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Nina Ricci Nina (80 мл)",
                    CategoryID = subCatWaterFemale.CategoryID,
                    PurPrice = 8200,
                    SellPrice = 9400,
                    Quantity = 9,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 12, 20),
                    ExpDate = new DateTime(2028, 12, 20)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Dior Miss Dior (100 мл)",
                    CategoryID = subCatWaterFemale.CategoryID,
                    PurPrice = 10500,
                    SellPrice = 12100,
                    Quantity = 7,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 01, 05),
                    ExpDate = new DateTime(2029, 01, 05)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Свежесть утра (100 мл)",
                    CategoryID = subCatWaterFemale.CategoryID,
                    PurPrice = 3200,
                    SellPrice = 3800,
                    Quantity = 30,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 10, 25),
                    ExpDate = new DateTime(2028, 10, 25)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Chanel Coco Mademoiselle (50 мл)",
                    CategoryID = subCatWaterPerfumFemale.CategoryID,
                    PurPrice = 14200,
                    SellPrice = 16300,
                    Quantity = 11,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 11, 10),
                    ExpDate = new DateTime(2028, 11, 10)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Lancôme Idôle (50 мл)",
                    CategoryID = subCatWaterPerfumFemale.CategoryID,
                    PurPrice = 10800,
                    SellPrice = 12500,
                    Quantity = 13,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 02, 18),
                    ExpDate = new DateTime(2029, 02, 18)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Giorgio Armani Si (50 мл)",
                    CategoryID = subCatWaterPerfumFemale.CategoryID,
                    PurPrice = 11500,
                    SellPrice = 13200,
                    Quantity = 8,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 09, 12),
                    ExpDate = new DateTime(2028, 09, 12)
                },

                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Dior Sauvage (60 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 8900,
                    SellPrice = 10200,
                    Quantity = 22,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 08, 05),
                    ExpDate = new DateTime(2028, 08, 05)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Bleu de Chanel (50 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 9800,
                    SellPrice = 11300,
                    Quantity = 16,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 10, 18),
                    ExpDate = new DateTime(2028, 10, 18)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Hugo Boss (75 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 6500,
                    SellPrice = 7500,
                    Quantity = 19,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2026, 01, 22),
                    ExpDate = new DateTime(2029, 01, 22)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Armani Code (50 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 7200,
                    SellPrice = 8300,
                    Quantity = 14,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 12, 08),
                    ExpDate = new DateTime(2028, 12, 08)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Мужская классика (50 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 3500,
                    SellPrice = 4100,
                    Quantity = 28,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 07, 19),
                    ExpDate = new DateTime(2028, 07, 19)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Дерзкий (50 мл)",
                    CategoryID = subCatDuhyMale.CategoryID,
                    PurPrice = 3800,
                    SellPrice = 4400,
                    Quantity = 20,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 11, 28),
                    ExpDate = new DateTime(2028, 11, 28)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Davidoff Cool Water (125 мл)",
                    CategoryID = subCatWaterMale.CategoryID,
                    PurPrice = 4500,
                    SellPrice = 5300,
                    Quantity = 35,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 05, 15),
                    ExpDate = new DateTime(2028, 05, 15)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Calvin Klein One (100 мл)",
                    CategoryID = subCatWaterMale.CategoryID,
                    PurPrice = 4200,
                    SellPrice = 4900,
                    Quantity = 25,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 09, 22),
                    ExpDate = new DateTime(2028, 09, 22)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Paco Rabanne 1 Million (100 мл)",
                    CategoryID = subCatWaterMale.CategoryID,
                    PurPrice = 7800,
                    SellPrice = 9100,
                    Quantity = 12,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 10, 30),
                    ExpDate = new DateTime(2028, 10, 30)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Brocard Спортивный (100 мл)",
                    CategoryID = subCatWaterMale.CategoryID,
                    PurPrice = 2900,
                    SellPrice = 3400,
                    Quantity = 40,
                    Units = MeasurementUnits.Milliliter,
                    ManufDate = new DateTime(2025, 08, 10),
                    ExpDate = new DateTime(2028, 08, 10)
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
                    ManufDate = new DateTime(2026, 02, 02),
                    ExpDate = new DateTime(2028, 03, 16)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Librederm Коллагеновый крем, 50 мл",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 780,
                    SellPrice = 850,
                    Quantity = 120,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 11, 10),
                    ExpDate = new DateTime(2027, 11, 10)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Vichy Minéral 89 (50 мл)",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 1850,
                    SellPrice = 2100,
                    Quantity = 45,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 09, 05),
                    ExpDate = new DateTime(2028, 09, 05)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "La Roche-Posay Cicaplast (100 мл)",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 950,
                    SellPrice = 1090,
                    Quantity = 60,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 10, 15),
                    ExpDate = new DateTime(2028, 10, 15)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "CeraVe Увлажняющий крем (177 мл)",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 1250,
                    SellPrice = 1450,
                    Quantity = 80,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 12, 01),
                    ExpDate = new DateTime(2028, 12, 01)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "The Ordinary Гиалуроновая кислота (30 мл)",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 520,
                    SellPrice = 590,
                    Quantity = 95,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2026, 01, 18),
                    ExpDate = new DateTime(2029, 01, 18)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Weleda Бальзам для губ (10 мл)",
                    CategoryID = catCare.CategoryID,
                    PurPrice = 260,
                    SellPrice = 320,
                    Quantity = 200,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 06, 14),
                    ExpDate = new DateTime(2028, 06, 14)
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
                    ManufDate = new DateTime(2024, 05, 18),
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
                    ManufDate = new DateTime(2023, 06, 09),
                    ExpDate = new DateTime(2026, 06, 09)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "KRYGINA Тональная основа PERFECT SKIN",
                    CategoryID = catDecor.CategoryID,
                    PurPrice = 890,
                    SellPrice = 1020,
                    Quantity = 38,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 05, 20),
                    ExpDate = new DateTime(2027, 05, 20)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "KRYGINA Матирующая пудра",
                    CategoryID = catDecor.CategoryID,
                    PurPrice = 720,
                    SellPrice = 830,
                    Quantity = 42,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 08, 12),
                    ExpDate = new DateTime(2027, 08, 12)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "KRYGINA Тушь для ресниц VOLUME",
                    CategoryID = catDecor.CategoryID,
                    PurPrice = 580,
                    SellPrice = 670,
                    Quantity = 65,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 10, 25),
                    ExpDate = new DateTime(2027, 10, 25)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "MAKE UP REVOLUTION Хайлайтер",
                    CategoryID = catDecor.CategoryID,
                    PurPrice = 680,
                    SellPrice = 790,
                    Quantity = 25,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 04, 10),
                    ExpDate = new DateTime(2027, 04, 10)
                },
                new Item
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "MAKE UP REVOLUTION Консилер",
                    CategoryID = catDecor.CategoryID,
                    PurPrice = 450,
                    SellPrice = 520,
                    Quantity = 55,
                    Units = MeasurementUnits.Piece,
                    ManufDate = new DateTime(2025, 07, 18),
                    ExpDate = new DateTime(2027, 07, 18)
                }
                });

                db.SaveChanges();
                Log.Information("База данных успешно заполнена");
            }
        }
    }
}