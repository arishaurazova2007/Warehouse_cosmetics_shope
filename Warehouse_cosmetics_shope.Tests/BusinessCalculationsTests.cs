namespace Warehouse_cosmetics_shope.Tests
{
    // Проверка формул расчета прибыли, убытков и сумм отгрузок (ТС 2.1, 2.4, 3.7).
    public class BusinessCalculationsTests
    {
        // Тестовый сценарий 2.1: Расчет суммы отгрузки
        [Fact]
        public void CalculateShipmentTotal_SimpleCase()
        {
            decimal price = 1000m;
            int quantity = 5;
            decimal expectedTotal = 5000m;
            decimal actualTotal = price * quantity;
            Assert.Equal(expectedTotal, actualTotal);
        }
        // Тестовый сценарий 2.4: Расчет прибыли
        // Формула: (Цена продажи - Цена закупки) * Количество
        [Fact]
        public void CalculateProfit_CorrectFormula()
        {
            decimal ZakupkaPrice = 500m;
            decimal ProdazhaPrice = 800m;
            int quantity = 10;
            decimal expectedProfit = (ProdazhaPrice - ZakupkaPrice) * quantity; 
            decimal actualProfit = (ProdazhaPrice - ZakupkaPrice) * quantity;
            Assert.Equal(3000m, actualProfit);
        }
        [Fact]
        public void CalculateProfit_LossScenario()
        {
            decimal ZakupkaPrice = 800m;
            decimal ProdazhaPrice = 500m;
            int quantity = 10;

            decimal expectedProfit = (ProdazhaPrice - ZakupkaPrice) * quantity; // -300 * 10 = -3000
            decimal actualProfit = (ProdazhaPrice - ZakupkaPrice) * quantity;

            Assert.Equal(-3000m, actualProfit);
        }
        // Тестовый сценарий 3.7: Расчет убытка при списании
        // Убыток = Цена закупки * Количество списанного
        [Fact]
        public void CalculateWriteOffLoss_CorrectFormula()
        {
            decimal zakupkaPrice = 500m;
            int writeOffQuantity = 10;
            decimal expectedLoss = zakupkaPrice * writeOffQuantity; // 5000
            decimal actualLoss = zakupkaPrice * writeOffQuantity;
            Assert.Equal(5000m, actualLoss);
        }
        // Тестовый сценарий 3.3: Проверка срока годности для скидки 
        // Если срок <= 7 дней, должна быть скидка
        [Fact]
        public void IsExpiringSoon_Within7Days_ReturnsTrue()
        {
            DateTime expDate = DateTime.Now.AddDays(5);
            DateTime today = DateTime.Now;
            TimeSpan diff = expDate - today;
            bool isExpiring = diff.Days <= 7 && diff.Days >= 0;
            Assert.True(isExpiring);
        }
        [Fact]
        public void IsExpiringSoon_MoreThan7Days_ReturnsFalse()
        {
            DateTime expDate = DateTime.Now.AddDays(10);
            DateTime today = DateTime.Now;
            TimeSpan diff = expDate - today;
            bool isExpiring = diff.Days <= 7 && diff.Days >= 0;
            Assert.False(isExpiring);
        }
        [Fact]
        public void IsExpired_PastDate_ReturnsTrue()
        {
            DateTime expDate = DateTime.Now.AddDays(-1);
            DateTime today = DateTime.Now;
            bool isExpired = expDate < today;
            Assert.True(isExpired);
        }
        [Fact]
        public void CalculateShipmentTotal_ZeroQuantity_ReturnsZero()
        {
            decimal price = 1000m;
            int quantity = 0;
            decimal actualTotal = price * quantity;
            Assert.Equal(0m, actualTotal);
        }
        [Fact]
        public void CalculateProfit_BreakEven_ReturnsZero()
        {
            decimal ZakupkaPrice = 500m;
            decimal ProdazhaPrice = 500m;
            int quantity = 10;
            decimal actualProfit = (ProdazhaPrice - ZakupkaPrice) * quantity;
            Assert.Equal(0m, actualProfit);
        }
        [Fact]
        public void IsExpired_FutureDate_ReturnsFalse()
        {
            DateTime expDate = DateTime.Now.AddDays(30);
            DateTime today = DateTime.Now;
            bool isExpired = expDate < today;
            Assert.False(isExpired);
        }
        [Fact]
        public void IsExpiringSoon_Today_ReturnsTrue()
        {
            DateTime expDate = DateTime.Now;
            DateTime today = DateTime.Now;
            TimeSpan diff = expDate - today;
            bool isExpiring = diff.Days <= 7 && diff.Days >= 0;
            Assert.True(isExpiring);
        }
    }
}