using System;
using NewsFeed.Core;
using NewsFeed.Data.Weather;

namespace NewsFeed.Cmd.Tools.Weather
{
    /// <summary>
    /// Weather forecase console printer.
    /// </summary>
    public class WeatherForecastConsolePrinter : IWeatherForecastConsolePrinter
    {
        private IConsolePrinter ConsolePrinter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastConsolePrinter"/> class.
        /// </summary>
        /// <param name="consolePrinter">Console printer.</param>
        public WeatherForecastConsolePrinter(IConsolePrinter consolePrinter)
        {
            this.ConsolePrinter = consolePrinter ?? throw new ArgumentNullException(nameof(consolePrinter));
        }

        /// <inheritdoc />
        public void PrintForecast(WeatherForecast weatherForecast)
        {
            Guard.IsNotNull(weatherForecast, nameof(weatherForecast));

            this.ConsolePrinter.WriteLine(Console.Out);
            this.ConsolePrinter.WriteLine(Console.Out, "*****************************************************************************************");
            this.ConsolePrinter.WriteLine(Console.Out, $"Forecast ID:\t\t{weatherForecast.Id}");
            this.ConsolePrinter.WriteLine(Console.Out, $"Location:\t\t{weatherForecast.LocationInState} ({weatherForecast.LocationState})");
            this.ConsolePrinter.WriteLine(Console.Out, $"Refresh message:\t{weatherForecast.RefreshMessage}");
            this.ConsolePrinter.WriteLine(Console.Out, "*****************************************************************************************");
            this.ConsolePrinter.WriteLine(Console.Out);

            if (weatherForecast.DayForecasts != null)
            {
                this.ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                this.ConsolePrinter.WriteLine(Console.Out, "|\tAir temperature (°C)\t|\tWind speed\t|\tForecast time\t\t|");
                this.ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                foreach (var dayForecast in weatherForecast.DayForecasts)
                {
                    this.ConsolePrinter.Write(Console.Out, $"|\t{dayForecast.AirTemperature}\t\t\t");
                    this.ConsolePrinter.Write(Console.Out, $"|\t{dayForecast.WindSpeedKmHr}km/hr {dayForecast.WindDirection}\t");
                    this.ConsolePrinter.WriteLine(Console.Out, $"|\t{dayForecast.LocalTime}\t{weatherForecast.TimeZone}\t|");
                }

                this.ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
            }
        }
    }
}
