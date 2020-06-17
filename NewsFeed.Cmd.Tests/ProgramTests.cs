using Moq;
using NewsFeed.Cmd.Tools;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Data.Weather;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NewsFeed.Cmd.Tests
{
    /// <summary>
    /// Program tests.
    /// </summary>
    public class ProgramTests
    {
        private Mock<ISydneyRegionWeatherForecast> MockSydneyRegionWeatherForecast { get; }

        private Mock<IWeatherForecastConsolePrinter> MockWeatherConsolePrinter { get; }

        private Program Program { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramTests"/> class.
        /// </summary>
        public ProgramTests()
        {
            this.MockSydneyRegionWeatherForecast = new Mock<ISydneyRegionWeatherForecast>();
            this.MockWeatherConsolePrinter = new Mock<IWeatherForecastConsolePrinter>();

            this.Program = new Program(new Mock<IServiceProvider>().Object, this.MockWeatherConsolePrinter.Object);
        }

        /// <summary>
        /// PrintNewsFeedAsync throws exception for null weather forecast.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task PrintNewsFeedAsync_NullSydneyRegionWeatherForecast_ThrowsException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => this.Program.PrintNewsFeedAsync(null));
        }

        /// <summary>
        /// PrintNewsFeedAsync for all data is successful.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task PrintNewsFeedAsync_AllData_Success()
        {
            var sydneyWeatherForecast = new WeatherForecast();
            this.MockSydneyRegionWeatherForecast
                .Setup(s => s.GetLatestForecastAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(sydneyWeatherForecast);

            await this.Program.PrintNewsFeedAsync(this.MockSydneyRegionWeatherForecast.Object);

            this.MockWeatherConsolePrinter.Verify(
                c => c.PrintForecast(sydneyWeatherForecast),
                Times.Once);
        }

        /// <summary>
        /// PrintNewsFeedAsync for no data is successful.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task PrintNewsFeedAsync_NoData_Success()
        {
            this.MockSydneyRegionWeatherForecast
                .Setup(s => s.GetLatestForecastAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((WeatherForecast)null));

            await this.Program.PrintNewsFeedAsync(this.MockSydneyRegionWeatherForecast.Object);

            this.MockWeatherConsolePrinter.Verify(
                c => c.PrintForecast(It.IsAny<WeatherForecast>()),
                Times.Never);
        }

        /// <summary>
        /// PrintToConsoleStartupMessage throws exception for null console printer.
        /// </summary>
        [Fact]
        public void PrintToConsoleStartupMessage_NullConsolePrinter_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.Program.PrintToConsoleStartupMessage(null));
        }

        /// <summary>
        /// PrintToConsoleShutdownMessage throws excetpion for null console printer.
        /// </summary>
        [Fact]
        public void PrintToConsoleShutdownMessage_NullConsolePrinter_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.Program.PrintToConsoleShutdownMessage(null));
        }

        /// <summary>
        /// PrintToConsoleStartupMessage  with valid console printer is successful.
        /// </summary>
        [Fact]
        public void PrintToConsoleStartupMessage_ValidConsolePrinter_Success()
        {
            var mockConsolePrinter = new Mock<IConsolePrinter>();
            mockConsolePrinter.Setup(c => c.WriteLine(Console.Out, It.IsAny<string>()));

            this.Program.PrintToConsoleStartupMessage(mockConsolePrinter.Object);

            mockConsolePrinter
                .Verify(c => c.WriteLine(Console.Out, It.IsAny<string>()), Times.Exactly(4));
        }

        /// <summary>
        /// PrintToConsoleShutdownMessage with valid console printer is successful.
        /// </summary>
        [Fact]
        public void PrintToConsoleShutdownMessage_ValidConsolePrinter_Success()
        {
            var mockConsolePrinter = new Mock<IConsolePrinter>();
            mockConsolePrinter.Setup(c => c.WriteLine(Console.Out, It.IsAny<string>()));

            this.Program.PrintToConsoleShutdownMessage(mockConsolePrinter.Object);

            mockConsolePrinter
                .Verify(c => c.WriteLine(Console.Out, It.IsAny<string>()), Times.Exactly(5));
        }
    }
}
