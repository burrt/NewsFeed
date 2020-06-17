using Moq;
using NewsFeed.Cmd.Tools;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Data.Weather;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace NewsFeed.Cmd.Tests.Tools.Weather
{
    /// <summary>
    /// Weather forecast console printer tests.
    /// </summary>
    public class WeatherForecastConsolePrinterTests
    {
        private Mock<IConsolePrinter> MockConsolePrinter { get; }

        private WeatherForecastConsolePrinter WeatherForecastConsolePrinter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastConsolePrinterTests"/> class.
        /// </summary>
        public WeatherForecastConsolePrinterTests()
        {
            this.MockConsolePrinter = new Mock<IConsolePrinter>();

            this.WeatherForecastConsolePrinter = new WeatherForecastConsolePrinter(this.MockConsolePrinter.Object);
        }

        /// <summary>
        /// PrintForecast throws exception for null forecast.
        /// </summary>
        [Fact]
        public void PrintForecast_NullForecast_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.WeatherForecastConsolePrinter.PrintForecast(null));
        }

        /// <summary>
        /// PrintForecast is successful for valid forecast.
        /// </summary>
        [Fact]
        public void PrintForecast_ValidForecast_Success()
        {
            var forecast = new WeatherForecast()
            {
                DayForecasts = new List<DayForecast>()
                {
                    new DayForecast()
                    {
                        AirTemperature = 1.0,
                        LocalTime = "09/09:30pm",
                        Location = "Sydney - Observatory Hill",
                        WindDirection = "NE",
                        WindSpeedKmHr = 1,
                    },
                },
            };

            this.WeatherForecastConsolePrinter.PrintForecast(forecast);

            this.MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(7));
            this.MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(2));
        }

        /// <summary>
        /// PrintForecast is successful for valid empty day forecast.
        /// </summary>
        [Fact]
        public void PrintForecast_ValidEmptyDayForecast_Success()
        {
            var forecast = new WeatherForecast()
            {
                DayForecasts = new List<DayForecast>(),
            };

            this.WeatherForecastConsolePrinter.PrintForecast(forecast);

            this.MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(6));
            this.MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Never);
        }

        /// <summary>
        /// PrintForecast is successful for valid null day forecast.
        /// </summary>
        [Fact]
        public void PrintForecast_ValidNullDayForecast_Success()
        {
            this.WeatherForecastConsolePrinter.PrintForecast(new WeatherForecast());

            this.MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Exactly(7));
            this.MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Never);
        }
    }
}
