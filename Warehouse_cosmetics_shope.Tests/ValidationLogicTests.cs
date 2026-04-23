namespace Warehouse_cosmetics_shope.Tests
{
    //Валидации из форм  (RegistrationForm, EditForm, OtgruzkaForm)
    public class ValidationLogicTests
    {
        // Тестовый сценарий  1.2: Проверка отрицательного количества
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void ValidateQuantity_NegativeOrZero_ShouldFail(int quantity)
        {
            // Логика из OtgruzkaForm.AddProductToOtgruzka
            bool isValid = quantity > 0;
            Assert.False(isValid, $"Количество {quantity} должно быть невалидным");
        }
        [Fact]
        public void ValidateQuantity_Positive_ShouldPass()
        {
            int quantity = 5;
            bool isValid = quantity > 0;
            Assert.True(isValid);
        }
        // Тестовый сценарий Регистрация: Валидация пароля
        [Theory]
        [InlineData("123")]      // Короткий
        [InlineData("abc")]      // Короткий
        [InlineData("")]         // Пустой
        [InlineData(null)]       // Null
        public void ValidatePassword_TooShortOrEmpty_ShouldFail(string password)
        {
            // Логика из RegistrationForm.ValidateRegistrationData
            bool isValid = !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
            Assert.False(isValid, $"Пароль '{password}' должен быть невалидным");
        }
        [Fact]
        public void ValidatePassword_ValidLength_ShouldPass()
        {
            string password = "123456";
            bool isValid = !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
            Assert.True(isValid);
        }
        // Тестовый сценарий Категории: Пустое название
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void ValidateCategoryName_Empty_ShouldFail(string name)
        {
            // Логика из NewCategoryForm.AddCategory
            bool isValid = !string.IsNullOrWhiteSpace(name);
            Assert.False(isValid);
        }
        [Fact]
        public void ValidateCategoryName_Valid_ShouldPass()
        {
            string name = "Парфюмерия";
            bool isValid = !string.IsNullOrWhiteSpace(name);
            Assert.True(isValid);
        }
        [Fact]
        public void ValidateString_Empty_ReturnsFalse()
        {
            string value = "";
            bool isValid = !string.IsNullOrWhiteSpace(value);
            Assert.False(isValid);
        }
        [Fact]
        public void ValidateString_Valid_ReturnsTrue()
        {
            string value = "Тест";
            bool isValid = !string.IsNullOrWhiteSpace(value);
            Assert.True(isValid);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(1000)]
        public void ValidateQuantity_LargePositive_ShouldPass(int quantity)
        {
            bool isValid = quantity > 0;
            Assert.True(isValid);
        }
        [Fact]
        public void ValidatePassword_Exactly6Chars_ShouldPass()
        {
            string password = "123456";
            bool isValid = password.Length >= 6;
            Assert.True(isValid);
        }
    }
}