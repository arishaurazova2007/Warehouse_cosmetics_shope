namespace Warehouse_cosmetics_shope.Tests
{
    // Тесты вспомогательных функций
    public class HelperTests
    {
        [Fact]
        public void Guid_NewGuid_NotEmpty()
        {
            Guid guid = Guid.NewGuid();
            Assert.NotEqual(Guid.Empty, guid);
        }
        [Fact]
        public void Guid_Empty_IsEmpty()
        {
            Guid guid = Guid.Empty;
            Assert.Equal(Guid.Empty, guid);
        }
        [Fact]
        public void DateTime_Parse_ValidDate_Success()
        {
            string dateString = "15.05.2025";
            bool success = DateTime.TryParse(dateString, out DateTime result);
            Assert.True(success);
        }
        [Fact]
        public void String_Trim_RemovesWhitespace()
        {
            string input = "  тест  ";
            string result = input.Trim();
            Assert.Equal("тест", result);
        }
        [Fact]
        public void Decimal_Parse_ValidNumber_Success()
        {
            string numberStr = "1234.56";
            bool success = decimal.TryParse(numberStr, out decimal result);
            Assert.True(success);
            Assert.Equal(1234.56m, result);
        }
    }
}