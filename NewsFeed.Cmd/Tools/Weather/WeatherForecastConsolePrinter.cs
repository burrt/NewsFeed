using System;
using NewsFeed.Core;
using NewsFeed.Data.Weather;

namespace NewsFeed.Cmd.Tools.Weather
{
    public class WeatherForecastConsolePrinter : IWeatherForecastConsolePrinter
    {
        private IConsolePrinter ConsolePrinter { get; }

        public WeatherForecastConsolePrinter(IConsolePrinter consolePrinter)
        {
            ConsolePrinter = consolePrinter ?? throw new ArgumentNullException(nameof(consolePrinter));
        }

        public void PrintForecast(WeatherForecast weatherForecast)
        {
            Guard.IsNotNull(weatherForecast, nameof(weatherForecast));

            ConsolePrinter.WriteLine(Console.Out);
            ConsolePrinter.WriteLine(Console.Out, "*****************************************************************************************");
            ConsolePrinter.WriteLine(Console.Out, $"Forecast ID:\t\t{weatherForecast.Id}");
            ConsolePrinter.WriteLine(Console.Out, $"Location:\t\t{weatherForecast.LocationInState} ({weatherForecast.LocationState})");
            ConsolePrinter.WriteLine(Console.Out, $"Refresh message:\t{weatherForecast.RefreshMessage}");
            ConsolePrinter.WriteLine(Console.Out, "*****************************************************************************************");
            ConsolePrinter.WriteLine(Console.Out);

            if (weatherForecast.DayForecasts != null)
            {
                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                ConsolePrinter.WriteLine(Console.Out, "|\tAir temperature (°C)\t|\tWind speed\t|\tForecast time\t\t|");
                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                foreach (var dayForecast in weatherForecast.DayForecasts)
                {
                    ConsolePrinter.Write(Console.Out, $"|\t{dayForecast.AirTemperature}\t\t\t");
                    ConsolePrinter.Write(Console.Out, $"|\t{dayForecast.WindSpeedKmHr}km/hr {dayForecast.WindDirection}\t");
                    ConsolePrinter.WriteLine(Console.Out, $"|\t{dayForecast.LocalTime}\t{weatherForecast.TimeZone}\t|");
                }

                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
            }
        }
    }
}
