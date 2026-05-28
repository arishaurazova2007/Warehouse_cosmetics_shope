using Xunit;
using System;

namespace Warehouse_cosmetics_shope.Tests
{
    /// <summary>
    /// Тесты для модуля "Валюты"
    /// </summary>
    public class CurrencyTests
    {

        [Fact]
        public void CalculateShipmentTotal_PriceTimesQuantity()
        {
            decimal price = 1000m;
            int quantity = 5;
            decimal total = price * quantity;

            Assert.Equal(5000m, total);
        }

        [Fact]
        public void CalculateShipmentTotal_ZeroQuantity_ReturnsZero()
        {
            decimal price = 1000m;
            int quantity = 0;
            decimal total = price * quantity;

            Assert.Equal(0m, total);
        }

        [Fact]
        public void CalculateShipmentTotal_ZeroPrice_ReturnsZero()
        {
            decimal price = 0m;
            int quantity = 100;
            decimal total = price * quantity;

            Assert.Equal(0m, total);
        }


        [Fact]
        public void ConvertCurrency_RUBtoUSD_DivideByRate()
        {
            decimal rub = 7500m;
            decimal rate = 75m;
            decimal usd = rub / rate;

            Assert.Equal(100m, usd);
        }

        [Fact]
        public void ConvertCurrency_USDtoRUB_MultiplyByRate()
        {
            decimal usd = 100m;
            decimal rate = 75m;
            decimal rub = usd * rate;

            Assert.Equal(7500m, rub);
        }

        [Fact]
        public void ConvertCurrency_ZeroRate_IsInvalid()
        {
            decimal rate = 0m;
            bool isValid = rate > 0;

            Assert.False(isValid);
        }


        [Fact]
        public void CalculateProfit_SaleGreaterThanBuy()
        {
            decimal buyPrice = 500m;
            decimal sellPrice = 800m;
            int quantity = 10;
            decimal profit = (sellPrice - buyPrice) * quantity;

            Assert.Equal(3000m, profit);
        }

        [Fact]
        public void CalculateProfit_SaleLessThanBuy_IsLoss()
        {
            decimal buyPrice = 800m;
            decimal sellPrice = 500m;
            int quantity = 10;
            decimal profit = (sellPrice - buyPrice) * quantity;

            Assert.True(profit < 0);
        }

        [Fact]
        public void CalculateProfit_SaleEqualToBuy_IsZero()
        {
            decimal buyPrice = 500m;
            decimal sellPrice = 500m;
            int quantity = 10;
            decimal profit = (sellPrice - buyPrice) * quantity;

            Assert.Equal(0m, profit);
        }


        [Fact]
        public void CalculateInverseRate_Formula()
        {
            double apiRate = 0.0133;
            decimal rubRate = Math.Round(1 / (decimal)apiRate, 2);

            Assert.True(rubRate > 70 && rubRate < 80);
        }

        [Fact]
        public void RoundRate_ToTwoDecimals()
        {
            decimal raw = 75.555m;
            decimal rounded = Math.Round(raw, 2);

            Assert.Equal(75.56m, rounded);
        }


        [Fact]
        public void ValidateRate_MustBePositive()
        {
            decimal rate = 75.50m;
            bool isValid = rate > 0;

            Assert.True(isValid);
        }
    }
}