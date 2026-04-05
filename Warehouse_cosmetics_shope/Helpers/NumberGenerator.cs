using System;
using System.Linq;
using Warehouse_cosmetics_shope.DataBaseClass;

namespace Warehouse_cosmetics_shope.Helpers
{
    public static class NumberGenerator
    {
        private static Random _random = new Random();

        /// <summary>
        /// Генерирует уникальный числовой ID для Items
        /// </summary>
        public static int GenerateProductNumber(WarehouseContext db)
        {
            int number;
            do
            {
                number = _random.Next(3000000, 5000000);
            } while (db.Items.Any(i => i.ProductNumber == number));

            return number;
        }

        /// <summary>
        /// Генерирует уникальный числовой ID для Clients
        /// </summary>
        public static int GenerateClientNumber(WarehouseContext db)
        {
            int number;
            do
            {
                number = _random.Next(6000000, 7000000);
            } while (db.Clients.Any(c => c.ClientNumber == number));

            return number;
        }

        /// <summary>
        /// Генерирует уникальный числовой ID для Shipments
        /// </summary>
        public static int GenerateShipmentNumber(WarehouseContext db)
        {
            int number;
            do
            {
                number = _random.Next(8000000, 20000000);
            } while (db.Shipments.Any(s => s.ShipmentNumber == number));

            return number;
        }
    }
}
