using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NewsFeed.Data.Weather;
using NewsFeed.Weather;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NewsFeed.Tests.Weather
{
    /// <summary>
    /// Weather Controller Tests.
    /// </summary>
    public class WeatherControllerTests
    {
        private WeatherController WeatherController { get; }
        private Mock<ISydneyRegionWeatherForecast> MockWeatherForecast { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherControllerTests"/> class.
        /// </summary>
        public WeatherControllerTests()
        {
            this.MockWeatherForecast = new Mock<ISydneyRegionWeatherForecast>();
            this.WeatherController = new WeatherController(this.MockWeatherForecast.Object);
        }

        /// <summary>
        /// Get sydney weather forecast is successful.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetSydneyForecast_Success()
        {
            // Arrange
            var validWeather = new WeatherForecast()
            {
                Id = Guid.NewGuid().ToString(),
                LocationInState = "test",
                LocationState = "test",
                TimeZone = "test",
                RefreshMessage = "test",
                DayForecasts = new List<DayForecast>()
                {
                    new DayForecast()
                    {
                        Location = "test",
                        LocalTime = "test",
                        AirTemperature = 1.0,
                        WindDirection = "test",
                        WindSpeedKmHr = 1,
                    },
                },
            };
            this.MockWeatherForecast
                .Setup(m => m.GetLatestForecastAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validWeather);

            // Act
            var result = await this.WeatherController.GetSydneyForecast() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.IsType<WeatherForecastViewModel>(result.Value);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            this.MockWeatherForecast.VerifyAll();
        }
    }
}
