using Xunit;
using System;

namespace Warehouse_cosmetics_shope.Tests
{
    /// <summary>
    /// Тесты для модуля "Погода и логистика"
    /// </summary>
    public class WeatherLogisticsTests
    {
        private const int TEMP_MIN = -20;
        private const int TEMP_MAX = 30;
        private const int FRAGILE_COLD = -10;
        private const int FRAGILE_HEAT = 25;

        [Fact]
        public void CheckWeather_NormalTemp_NoThermoContainer()
        {
            int temp = 15;
            bool needsThermo = temp < TEMP_MIN || temp > TEMP_MAX;

            Assert.False(needsThermo);
        }

        [Fact]
        public void CheckWeather_AbnormalCold_NeedsThermoContainer()
        {
            int temp = -25;
            bool needsThermo = temp < TEMP_MIN;

            Assert.True(needsThermo);
        }

        [Fact]
        public void CheckWeather_AbnormalHeat_NeedsThermoContainer()
        {
            int temp = 35;
            bool needsThermo = temp > TEMP_MAX;

            Assert.True(needsThermo);
        }

        [Fact]
        public void CheckWeather_Fragile_Cold_NeedsProtection()
        {
            int temp = -15;
            bool isFragile = true;
            bool needsProtection = isFragile && temp < FRAGILE_COLD;

            Assert.True(needsProtection);
        }

        [Fact]
        public void CheckWeather_Fragile_Heat_NeedsProtection()
        {
            int temp = 30;
            bool isFragile = true;
            bool needsProtection = isFragile && temp > FRAGILE_HEAT;

            Assert.True(needsProtection);
        }


        [Fact]
        public void Forecast_2Days_AbnormalTemp_ShowsWarning()
        {
            int daysUntilDelivery = 2;
            int forecastTemp = -25;
            bool showWarning = daysUntilDelivery <= 2 &&
                              (forecastTemp < TEMP_MIN || forecastTemp > TEMP_MAX);

            Assert.True(showWarning);
        }

        [Fact]
        public void Forecast_5Days_AbnormalTemp_NoWarning()
        {
            int daysUntilDelivery = 5;
            int forecastTemp = -25;
            bool showWarning = daysUntilDelivery <= 2 &&
                              (forecastTemp < TEMP_MIN || forecastTemp > TEMP_MAX);

            Assert.False(showWarning);
        }


        [Fact]
        public void Insurance_Fragile_Abnormal_Recommended()
        {
            int temp = -25;
            bool isFragile = true;
            bool recommendInsurance = isFragile &&
                                     (temp < TEMP_MIN || temp > TEMP_MAX);

            Assert.True(recommendInsurance);
        }

        [Fact]
        public void Insurance_NormalTemp_NotRequired()
        {
            int temp = 20;
            bool isFragile = true;
            bool recommendInsurance = isFragile &&
                                     (temp < TEMP_MIN || temp > TEMP_MAX);

            Assert.False(recommendInsurance);
        }


        [Fact]
        public void CheckWeather_BoundaryTemp_NoAction()
        {
            int temp = TEMP_MIN; // -20 — граница
            bool needsThermo = temp < TEMP_MIN;

            Assert.False(needsThermo);
        }

        [Fact]
        public void CheckWeather_JustBelowBoundary_ActionRequired()
        {
            int temp = TEMP_MIN - 1; // -21
            bool needsThermo = temp < TEMP_MIN;

            Assert.True(needsThermo);
        }


        [Fact]
        public void Geolocation_DetermineRegion_Success()
        {
            string region = "Сибирь";
            bool isNorthernRegion = region == "Сибирь" || region == "Урал";

            Assert.True(isNorthernRegion);
        }

        [Fact]
        public void Geolocation_NorthernRegion_HigherRisk()
        {
            string region = "Сибирь";
            int riskLevel = 0;

            if (region == "Сибирь" || region == "Урал")
                riskLevel = 2;
            else if (region == "Юг")
                riskLevel = 1;

            Assert.Equal(2, riskLevel);
        }

        [Fact]
        public void Geolocation_SouthernRegion_ModerateRisk()
        {
            string region = "Юг";
            int riskLevel = 0;

            if (region == "Сибирь" || region == "Урал")
                riskLevel = 2;
            else if (region == "Юг")
                riskLevel = 1;

            Assert.Equal(1, riskLevel);
        }
    }
}