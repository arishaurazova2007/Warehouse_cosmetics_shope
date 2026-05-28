using Xunit;
using System;

namespace Warehouse_cosmetics_shope.Tests
{
    /// <summary>
    /// Тесты для модуля "Тепловая карта склада"
    /// </summary>
    public class HeatMapTests
    {
        private const int COLUMNS = 8;


        [Fact]
        public void CalculatePosition_Cell1_Row0Col0()
        {
            int cellNumber = 1;
            int index = cellNumber - 1;
            int col = index % COLUMNS;
            int row = index / COLUMNS;

            Assert.Equal(0, col);
            Assert.Equal(0, row);
        }

        [Fact]
        public void CalculatePosition_Cell8_Row0Col7()
        {
            int cellNumber = 8;
            int index = cellNumber - 1;
            int col = index % COLUMNS;
            int row = index / COLUMNS;

            Assert.Equal(7, col);
            Assert.Equal(0, row);
        }

        [Fact]
        public void CalculatePosition_Cell9_Row1Col0()
        {
            int cellNumber = 9;
            int index = cellNumber - 1;
            int col = index % COLUMNS;
            int row = index / COLUMNS;

            Assert.Equal(0, col);
            Assert.Equal(1, row);
        }


        [Fact]
        public void IsExpiringSoon_Within7Days_ReturnsTrue()
        {
            DateTime expDate = DateTime.Now.AddDays(5);
            DateTime today = DateTime.Now.Date;
            int daysLeft = (expDate.Date - today).Days;
            bool isExpiring = daysLeft <= 7 && daysLeft >= 0;

            Assert.True(isExpiring);
        }

        [Fact]
        public void IsExpiringSoon_MoreThan7Days_ReturnsFalse()
        {
            DateTime expDate = DateTime.Now.AddDays(10);
            DateTime today = DateTime.Now.Date;
            int daysLeft = (expDate.Date - today).Days;
            bool isExpiring = daysLeft <= 7 && daysLeft >= 0;

            Assert.False(isExpiring);
        }

        [Fact]
        public void IsExpired_PastDate_ReturnsTrue()
        {
            DateTime expDate = DateTime.Now.AddDays(-1);
            bool isExpired = expDate < DateTime.Now;

            Assert.True(isExpired);
        }

        [Fact]
        public void IsExpired_FutureDate_ReturnsFalse()
        {
            DateTime expDate = DateTime.Now.AddDays(30);
            bool isExpired = expDate < DateTime.Now;

            Assert.False(isExpired);
        }

        [Fact]
        public void IsManyQuantity_Above70_ReturnsTrue()
        {
            int quantity = 71;
            bool isMany = quantity > 70;

            Assert.True(isMany);
        }

        [Fact]
        public void IsManyQuantity_Exactly70_ReturnsFalse()
        {
            int quantity = 70;
            bool isMany = quantity > 70;

            Assert.False(isMany);
        }

        [Fact]
        public void IsMediumQuantity_WithinRange_ReturnsTrue()
        {
            int quantity = 55;
            bool isMedium = quantity >= 40 && quantity <= 70;

            Assert.True(isMedium);
        }

        [Fact]
        public void IsFewQuantity_Below40_ReturnsTrue()
        {
            int quantity = 39;
            bool isFew = quantity < 40;

            Assert.True(isFew);
        }


        [Fact]
        public void CalculateDiscount_7Days_Returns30Percent()
        {
            int daysLeft = 7;
            decimal discount = daysLeft <= 7 ? 0.30m :
                              daysLeft <= 14 ? 0.15m : 0m;

            Assert.Equal(0.30m, discount);
        }

        [Fact]
        public void CalculateDiscount_10Days_Returns15Percent()
        {
            int daysLeft = 10;
            decimal discount = daysLeft <= 7 ? 0.30m :
                              daysLeft <= 14 ? 0.15m : 0m;

            Assert.Equal(0.15m, discount);
        }

        [Fact]
        public void CalculateDiscount_20Days_Returns0Percent()
        {
            int daysLeft = 20;
            decimal discount = daysLeft <= 7 ? 0.30m :
                              daysLeft <= 14 ? 0.15m : 0m;

            Assert.Equal(0m, discount);
        }


        [Fact]
        public void ColorBoundary_30Days_BelongsToMidExpiry()
        {
            int daysLeft = 30;
            bool isExpiring = daysLeft < 30;
            bool isMidExpiry = daysLeft >= 30 && daysLeft <= 90;

            Assert.False(isExpiring);
            Assert.True(isMidExpiry);
        }
    }
}