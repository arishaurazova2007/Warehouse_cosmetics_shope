//namespace Warehouse_cosmetics_shope.Tests
//{
//    public class FilterCriteriaTests
//    {
//        // Проверка логики сбора фильтров (FiltrationForm)
//        [Fact]
//        public void FilterCriteria_DefaultValues_AllFalseOrEmpty()
//        {
//            var criteria = new FilterCriteria();
//            Assert.False(criteria.CategoryPerfumeMen);
//            Assert.False(criteria.CategoryPerfumeWomen);
//            Assert.False(criteria.CategoryCosmetics);
//            Assert.False(criteria.TypePerfume);
//            Assert.Null(criteria.PriceFrom);
//            Assert.Null(criteria.PriceTo);
//        }
//        [Fact]
//        public void FilterCriteria_SetValues_ShouldStoreCorrectly()
//        {
//            var criteria = new FilterCriteria
//            {
//                CategoryPerfumeMen = true,
//                PriceFrom = "1000",
//                PriceTo = "5000",
//                InStock = true
//            };
//            Assert.True(criteria.CategoryPerfumeMen);
//            Assert.Equal("1000", criteria.PriceFrom);
//            Assert.Equal("5000", criteria.PriceTo);
//            Assert.True(criteria.InStock);
//        }
//        [Fact]
//        public void FilterCriteria_PriceParsing_ValidDecimal()
//        {
//            string priceStr = "1234.56";
//            bool success = decimal.TryParse(priceStr, out decimal result);
//            Assert.True(success);
//            Assert.Equal(1234.56m, result);
//        }
//        [Fact]
//        public void FilterCriteria_PriceParsing_InvalidString()
//        {
//            string priceStr = "abc";
//            bool success = decimal.TryParse(priceStr, out decimal result);
//            Assert.False(success);
//            Assert.Equal(0, result);
//        }
//        [Fact]
//        public void FilterCriteria_AllCategories_CanBeSelected()
//        {
//            var criteria = new FilterCriteria
//            {
//                CategoryPerfumeMen = true,
//                CategoryPerfumeWomen = true,
//                CategoryCosmetics = true
//            };
//            Assert.True(criteria.CategoryPerfumeMen);
//            Assert.True(criteria.CategoryPerfumeWomen);
//            Assert.True(criteria.CategoryCosmetics);
//        }
//        [Fact]
//        public void FilterCriteria_AllTypes_CanBeSelected()
//        {
//            var criteria = new FilterCriteria
//            {
//                TypePerfume = true,
//                TypePerfumeWater = true,
//                TypeToiletWater = true,
//                TypeCare = true,
//                TypeDecor = true
//            };
//            Assert.True(criteria.TypePerfume);
//            Assert.True(criteria.TypeDecor);
//        }
//        [Fact]
//        public void FilterCriteria_PriceFrom_CanBeNull()
//        {
//            var criteria = new FilterCriteria();
//            Assert.Null(criteria.PriceFrom);
//        }
//        [Fact]
//        public void FilterCriteria_PriceTo_CanBeEmpty()
//        {
//            var criteria = new FilterCriteria
//            {
//                PriceTo = ""
//            };
//            Assert.Equal("", criteria.PriceTo);
//        }
//    }
//}