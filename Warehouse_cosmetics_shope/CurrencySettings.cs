using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_cosmetics_shope
{
    /// <summary>
    /// Хранит текущую выбранную валюту в памяти пока программа запущена
    /// </summary>
    public static class CurrencySettings
    {
        public static string CurrentCurrency { get; set; } = "RUB";
        public static decimal CurrentRate { get; set; } = 1.00m;
    }
}
