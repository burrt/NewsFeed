using NewsFeed.Data.Weather;
using System;

namespace NewsFeed.Cmd.ConsolePrinters.Weather
{
    public static class WeatherForecastConsolePrinter
    {
        public static void PrintForecast(WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                throw new ArgumentNullException(nameof(weatherForecast));
            }

            Console.WriteLine();
            Console.WriteLine("******************************************************************************");
            Console.WriteLine($"Forecast ID:		{weatherForecast.Id}");
            Console.WriteLine($"Location:		{weatherForecast.LocationInState} ({weatherForecast.LocationState})");
            Console.WriteLine($"Refresh message:	{weatherForecast.RefreshMessage}");
            Console.WriteLine();

            if (weatherForecast.DayForecasts != null)
            {
                Console.WriteLine("+---------------------------------------------------------------------------------------+");
                Console.WriteLine("|	Air temperature (°C)	|	Wind speed	|	Forecast time		|");
                Console.WriteLine("+---------------------------------------------------------------------------------------+");
                foreach (var dayForecast in weatherForecast.DayForecasts)
                {
                    Console.Write($"|	{dayForecast.AirTemperature}			");
                    Console.Write($"|	{dayForecast.WindSpeedKmHr}km/hr {dayForecast.WindDirection}	");
                    Console.WriteLine($"|	{dayForecast.LocalTime}	{weatherForecast.TimeZone}	|");
                }

                Console.WriteLine("+---------------------------------------------------------------------------------------+");
            }
        }
    }
}
