using NewsFeed.Data.Weather;

namespace NewsFeed.Cmd.Tools.Weather
{
    /// <summary>
    /// Weather forecast console printer.
    /// </summary>
    public interface IWeatherForecastConsolePrinter
    {
        /// <summary>
        /// Prints the weather forecast to the console.
        /// </summary>
        /// <param name="weatherForecast">Weather forecast to print.</param>
        void PrintForecast(WeatherForecast weatherForecast);
    }
}
