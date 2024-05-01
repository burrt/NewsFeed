using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NewsFeed.Data.Weather;
using NewsFeed.Data.WeatherFeed.Australia.NSW;
using WeatherFeed.Australia.NSW;
using WeatherFeed.Http.Australia;
using Xunit;


namespace WeatherFeed.Tests.Australia.NSW
{
    /// <summary>
    /// Sydney region weather forecase tests.
    /// </summary>
    public class SydneyRegionWeatherForecastTests
    {
        private Mock<IBomAustraliaApiRunner> MockBomSydneyRegionApiRunner { get; }

        private SydneyRegionWeatherForecast SydneyRegionWeatherForecast { get; }

        private List<BomHeader> ValidSydneyWeatherForecastHeader { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SydneyRegionWeatherForecastTests"/> class.
        /// </summary>
        public SydneyRegionWeatherForecastTests()
        {
            this.MockBomSydneyRegionApiRunner = new Mock<IBomAustraliaApiRunner>();
            this.SydneyRegionWeatherForecast = new SydneyRegionWeatherForecast(this.MockBomSydneyRegionApiRunner.Object);
            this.ValidSydneyWeatherForecastHeader = new List<BomHeader>()
            {
                new BomHeader()
                {
                    ID = "IDN60901",
                    main_ID = "IDN60900",
                    name = "Sydney - Observatory Hill",
                    state_time_zone = "NSW",
                    time_zone = "EDT",
                    product_name = "Capital City Observations",
                    state = "New South Wales",
                    refresh_message = "Issued at  4:11 pm EDT Friday 15 November 2019",
                },
            };
        }

        /// <summary>
        /// GetLatestForecastAsync throws exception when forecast is null.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestForecastAsync_NoForecastAvailable_ThrowsException()
        {
            // Arrange
            this.MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BomLatestWeatherForecast>(null));

            // Act
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.SydneyRegionWeatherForecast.GetLatestForecastAsync());

            // Assert
            this.MockBomSydneyRegionApiRunner
                .Verify(
                    b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        /// <summary>
        /// GetLatestSydneyRegionForecastAsync throws exception on null oberservations forecast.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestForecastAsync_NullObservationsForecast_ThrowsException()
        {
            // Arrange
            var nullObservationsForecast = new BomLatestWeatherForecast()
            {
                observations = null,
            };
            this.MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(nullObservationsForecast));

            // Act
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.SydneyRegionWeatherForecast.GetLatestForecastAsync());

            // Assert
            this.MockBomSydneyRegionApiRunner
                .Verify(
                    b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        /// <summary>
        /// GetLatestSydneyRegionForecastAsync throws exception on null data forecast.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestForecastAsync_NullDataForecast_ThrowsException()
        {
            // Arrange
            var nullObservationsForecast = new BomLatestWeatherForecast()
            {
                observations = new BomObservations()
                {
                    header = this.ValidSydneyWeatherForecastHeader,
                    data = null,
                },
            };
            this.MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(nullObservationsForecast));

            // Act
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.SydneyRegionWeatherForecast.GetLatestForecastAsync());

            // Assert
            this.MockBomSydneyRegionApiRunner
                .Verify(
                    b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        /// <summary>
        /// GetLatestSydneyRegionForecastAsync with empty day forecast is sucessful.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestForecastAsync_EmptyDayForecast_Success()
        {
            // Arrange
            var emptyDayForecast = new BomLatestWeatherForecast()
            {
                observations = new BomObservations()
                {
                    header = this.ValidSydneyWeatherForecastHeader,
                    data = new List<BomData>(),
                },
            };
            this.MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(emptyDayForecast));

            // Act
            var weatherForecast = await this.SydneyRegionWeatherForecast.GetLatestForecastAsync();

            // Assert
            this.MockBomSydneyRegionApiRunner
                .Verify(
                    b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()),
                    Times.Once);
            AssertValidWeatherForecastMetadata(weatherForecast);
            Assert.Empty(weatherForecast.DayForecasts);
        }

        /// <summary>
        /// GetLatestSydneyRegionForecastAsync with valid forecast is successful.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestForecastAsync_ValidForecast_Success()
        {
            // Arrange
            var validDayForecast = new BomLatestWeatherForecast()
            {
                observations = new BomObservations()
                {
                    header = this.ValidSydneyWeatherForecastHeader,
                    data = new List<BomData>()
                    {
                        new BomData()
                        {
                            sort_order = 0,
                            name = "Sydney - Observatory Hill",
                            local_date_time = "15/04:00pm",
                            aifstime_utc = 20191115050000,
                            air_temp = 26.4,
                            wind_dir = "NE",
                            wind_spd_kmh = 11,
                        },
                    },
                },
            };
            this.MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(validDayForecast));

            // Act
            var weatherForecast = await this.SydneyRegionWeatherForecast.GetLatestForecastAsync();

            // Assert
            this.MockBomSydneyRegionApiRunner
                .Verify(
                    b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()),
                    Times.Once);
            AssertValidWeatherForecastMetadata(weatherForecast);
            Assert.Single(weatherForecast.DayForecasts);
            Assert.Equal("Sydney - Observatory Hill", weatherForecast.DayForecasts[0].Location);
            Assert.Equal("15/04:00pm", weatherForecast.DayForecasts[0].LocalTime);
            Assert.Equal(26.4, weatherForecast.DayForecasts[0].AirTemperature);
            Assert.Equal("NE", weatherForecast.DayForecasts[0].WindDirection);
            Assert.Equal(11, weatherForecast.DayForecasts[0].WindSpeedKmHr);
        }

        /// <summary>
        /// Validate the weather forecast metadata from the BOM.
        /// </summary>
        /// <param name="weatherForecast">Weather forecast to validate.</param>
        private static void AssertValidWeatherForecastMetadata(WeatherForecast weatherForecast)
        {
            Assert.NotNull(weatherForecast);
            Assert.Equal("IDN60901", weatherForecast.Id);
            Assert.Equal("Sydney - Observatory Hill", weatherForecast.LocationInState);
            Assert.Equal("EDT", weatherForecast.TimeZone);
            Assert.Equal("New South Wales", weatherForecast.LocationState);
            Assert.Equal("Issued at  4:11 pm EDT Friday 15 November 2019", weatherForecast.RefreshMessage);
        }
    }
}
