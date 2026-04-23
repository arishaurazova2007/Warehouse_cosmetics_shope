using NLog;
namespace Warehouse_cosmetics_shope.Tests
{
    // Тесты логгера 
    public class LoggerTests
    {
        [Fact]
        public void Logger_CreateInstance_ShouldNotBeNull()
        {
            var logger = LogManager.GetCurrentClassLogger();
            Assert.NotNull(logger);
        }

        [Fact]
        public void Logger_InfoLevel_IsEnabled()
        {
            var logger = LogManager.GetCurrentClassLogger();
            Assert.True(logger.IsInfoEnabled);
        }

        [Fact]
        public void Logger_ErrorLevel_IsEnabled()
        {
            var logger = LogManager.GetCurrentClassLogger();
            Assert.True(logger.IsErrorEnabled);
        }
    }
}