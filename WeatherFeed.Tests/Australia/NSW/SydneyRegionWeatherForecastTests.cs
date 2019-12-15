using Moq;
using NewsFeed.Data.Australia.NSW;
using NewsFeed.Http.Australia.NSW;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherFeed.Australia.NSW;
using Xunit;

namespace WeatherFeed.Tests.Australia.NSW
{
    public class SydneyRegionWeatherForecastTests
    {
        private Mock<IBomSydneyRegionApiRunner> MockBomSydneyRegionApiRunner { get; }
        private SydneyRegionWeatherForecast SydneyRegionWeatherForecast { get; }

        public SydneyRegionWeatherForecastTests()
        {
            MockBomSydneyRegionApiRunner = new Mock<IBomSydneyRegionApiRunner>();

            SydneyRegionWeatherForecast = new SydneyRegionWeatherForecast(MockBomSydneyRegionApiRunner.Object);
        }

        [Fact]
        public async Task GetLatestForecastAsync_NoForecastAvailable_ThrowsInvalidOperationException()
        {
            // Arrange
            MockBomSydneyRegionApiRunner
                .Setup(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<BomLatestWeatherForecast>(null));

            // Act
            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => SydneyRegionWeatherForecast.GetLatestForecastAsync());

            MockBomSydneyRegionApiRunner
                .Verify(b => b.GetLatestSydneyRegionForecastAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
