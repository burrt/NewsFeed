using Moq;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Data.Weather;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewsFeed.Cmd.Tools;
using Xunit;

namespace NewsFeed.Cmd.Tests
{
    public class ProgramTests
    {
        private Mock<ISydneyRegionWeatherForecast> MockSydneyRegionWeatherForecast { get; }
        private Mock<IWeatherForecastConsolePrinter> MockWeatherConsolePrinter { get; }
        private Program Program { get; }

        public ProgramTests()
        {
            MockSydneyRegionWeatherForecast = new Mock<ISydneyRegionWeatherForecast>();
            MockWeatherConsolePrinter = new Mock<IWeatherForecastConsolePrinter>();

            Program = new Program(new Mock<IServiceProvider>().Object, MockWeatherConsolePrinter.Object);
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

            MockWeatherConsolePrinter.Verify(
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

            MockWeatherConsolePrinter.Verify(
                c => c.PrintForecast(It.IsAny<WeatherForecast>()),
                Times.Never);
        }

        [Fact]
        public void PrintToConsoleStartupMessage_NullConsolePrinter_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Program.PrintToConsoleStartupMessage(null));
        }

        [Fact]
        public void PrintToConsoleShutdownMessage_NullConsolePrinter_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Program.PrintToConsoleShutdownMessage(null));
        }

        [Fact]
        public void PrintToConsoleStartupMessage_ValidConsolePrinter_Success()
        {
            var mockConsolePrinter = new Mock<IConsolePrinter>();
            mockConsolePrinter.Setup(c => c.WriteLine(Console.Out, It.IsAny<string>()));

            Program.PrintToConsoleStartupMessage(mockConsolePrinter.Object);

            mockConsolePrinter
                .Verify(c => c.WriteLine(Console.Out, It.IsAny<string>()), Times.Exactly(4));
        }

        [Fact]
        public void PrintToConsoleShutdownMessage_ValidConsolePrinter_Success()
        {
            var mockConsolePrinter = new Mock<IConsolePrinter>();
            mockConsolePrinter.Setup(c => c.WriteLine(Console.Out, It.IsAny<string>()));

            Program.PrintToConsoleShutdownMessage(mockConsolePrinter.Object);

            mockConsolePrinter
                .Verify(c => c.WriteLine(Console.Out, It.IsAny<string>()), Times.Exactly(5));
        }
    }
}
