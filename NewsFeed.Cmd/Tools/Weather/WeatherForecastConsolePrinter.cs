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
            ConsolePrinter.WriteLine(Console.Out, "******************************************************************************");
            ConsolePrinter.WriteLine(Console.Out, $"Forecast ID:		{weatherForecast.Id}");
            ConsolePrinter.WriteLine(Console.Out, $"Location:		{weatherForecast.LocationInState} ({weatherForecast.LocationState})");
            ConsolePrinter.WriteLine(Console.Out, $"Refresh message:	{weatherForecast.RefreshMessage}");
            ConsolePrinter.WriteLine(Console.Out);

            if (weatherForecast.DayForecasts != null)
            {
                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                ConsolePrinter.WriteLine(Console.Out, "|	Air temperature (°C)	|	Wind speed	|	Forecast time		|");
                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
                foreach (var dayForecast in weatherForecast.DayForecasts)
                {
                    ConsolePrinter.Write(Console.Out, $"|	{dayForecast.AirTemperature}			");
                    ConsolePrinter.Write(Console.Out, $"|	{dayForecast.WindSpeedKmHr}km/hr {dayForecast.WindDirection}	");
                    ConsolePrinter.WriteLine(Console.Out, $"|	{dayForecast.LocalTime}	{weatherForecast.TimeZone}	|");
                }

                ConsolePrinter.WriteLine(Console.Out, "+---------------------------------------------------------------------------------------+");
            }
        }
    }
}
