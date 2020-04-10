using Moq;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Data.Weather;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NewsFeed.Cmd.Tests
{
    public class ProgramTests
    {
        private Mock<ISydneyRegionWeatherForecast> MockSydneyRegionWeatherForecast { get; }
        private Mock<IWeatherForecastConsolePrinter> MockConsolePrinter { get; }
        private Program Program { get; }

        public ProgramTests()
        {
            MockSydneyRegionWeatherForecast = new Mock<ISydneyRegionWeatherForecast>();
            MockConsolePrinter = new Mock<IWeatherForecastConsolePrinter>();

            Program = new Program(new Mock<IServiceProvider>().Object, MockConsolePrinter.Object);
        }

        [Fact]
        public async Task PrintNewsFeedAsync_NullSydneyRegionWeatherForecast_ThrowsException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => Program.PrintNewsFeedAsync(null));
        }

        [Fact]
        public async Task PrintNewsFeedAsync_AllData_Success()
        {
            var sydneyWeatherForecast = new WeatherForecast();
            MockSydneyRegionWeatherForecast
                .Setup(s => s.GetLatestForecastAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(sydneyWeatherForecast);

            await Program.PrintNewsFeedAsync(MockSydneyRegionWeatherForecast.Object);

            MockConsolePrinter.Verify(
                c => c.PrintForecast(sydneyWeatherForecast),
                Times.Once);
        }

        [Fact]
        public async Task PrintNewsFeedAsync_NoData_Success()
        {
            MockSydneyRegionWeatherForecast
                .Setup(s => s.GetLatestForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((WeatherForecast) null));

            await Program.PrintNewsFeedAsync(MockSydneyRegionWeatherForecast.Object);

            MockConsolePrinter.Verify(
                c => c.PrintForecast(It.IsAny<WeatherForecast>()),
                Times.Never);
        }
    }
}
