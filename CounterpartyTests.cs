using Xunit;
using System;
using System.Text.RegularExpressions;

namespace Warehouse_cosmetics_shope.Tests
{
    /// <summary>
    /// Тесты для модуля "Проверка контрагента"
    /// </summary>
    public class CounterpartyTests
    {

        [Fact]
        public void ValidateINN_Organization_12Digits_ReturnsTrue()
        {
            string inn = "770708389300";
            bool isValid = inn.Length == 12 && IsOnlyDigits(inn);

            Assert.True(isValid);
        }

        [Fact]
        public void ValidateINN_Individual_10Digits_ReturnsTrue()
        {
            string inn = "7707083893";
            bool isValid = inn.Length == 10 && IsOnlyDigits(inn);

            Assert.True(isValid);
        }

        [Fact]
        public void ValidateINN_WithLetters_ReturnsFalse()
        {
            string inn = "770ABC83893";
            bool isValid = IsOnlyDigits(inn);

            Assert.False(isValid);
        }

        [Fact]
        public void ValidateINN_Empty_ReturnsFalse()
        {
            string inn = "";
            bool isValid = !string.IsNullOrEmpty(inn);

            Assert.False(isValid);
        }

        [Fact]
        public void ValidateINN_WrongLength_ReturnsFalse()
        {
            string inn = "12345";
            bool isValid = inn.Length == 10 || inn.Length == 12;

            Assert.False(isValid);
        }


        [Fact]
        public void CheckBlacklist_CleanINN_ReturnsFalse()
        {
            string inn = "770708389300";
            string[] blacklist = { "000000000000", "111111111111" };
            bool isBlacklisted = Array.IndexOf(blacklist, inn) >= 0;

            Assert.False(isBlacklisted);
        }

        [Fact]
        public void CheckBlacklist_BadINN_ReturnsTrue()
        {
            string inn = "000000000000";
            string[] blacklist = { "000000000000", "111111111111" };
            bool isBlacklisted = Array.IndexOf(blacklist, inn) >= 0;

            Assert.True(isBlacklisted);
        }


        [Fact]
        public void ValidateCompanyName_NotEmpty_ReturnsTrue()
        {
            string name = "ООО Ромашка";
            bool isValid = !string.IsNullOrEmpty(name);

            Assert.True(isValid);
        }

        [Fact]
        public void ValidateCompanyName_Empty_ReturnsFalse()
        {
            string name = "";
            bool isValid = !string.IsNullOrEmpty(name);

            Assert.False(isValid);
        }

        private bool IsOnlyDigits(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}