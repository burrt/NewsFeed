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
    public class WeatherForecastConsolePrinterTests
    {
        private Mock<IConsolePrinter> MockConsolePrinter { get; }
        private WeatherForecastConsolePrinter WeatherForecastConsolePrinter { get; }

        public WeatherForecastConsolePrinterTests()
        {
            MockConsolePrinter = new Mock<IConsolePrinter>();

            WeatherForecastConsolePrinter = new WeatherForecastConsolePrinter(MockConsolePrinter.Object);
        }

        [Fact]
        public void PrintForecast_NullForecast_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => WeatherForecastConsolePrinter.PrintForecast(null));
        }

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
                    }
                }
            };

            WeatherForecastConsolePrinter.PrintForecast(forecast);

            MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(7));
            MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(2));
        }

        [Fact]
        public void PrintForecast_ValidEmptyDayForecast_Success()
        {
            var forecast = new WeatherForecast()
            {
                DayForecasts = new List<DayForecast>()
            };

            WeatherForecastConsolePrinter.PrintForecast(forecast);

            MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.AtLeast(6));
            MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Never);
        }

        [Fact]
        public void PrintForecast_ValidNullDayForecast_Success()
        {
            WeatherForecastConsolePrinter.PrintForecast(new WeatherForecast());

            MockConsolePrinter.Verify(
                c => c.WriteLine(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Exactly(7));
            MockConsolePrinter.Verify(
                c => c.Write(It.IsAny<TextWriter>(), It.IsAny<string>()),
                Times.Never);
        }
    }
}
