using System.Threading;
using System.Threading.Tasks;
using NewsFeed.Data.Weather;


namespace NewsFeed.Weather.Australia.NSW
{
    /// <summary>
    /// Interface for getting the weather forecast for the Sydney Region.
    /// </summary>
    public interface ISydneyRegionWeatherForecast
    {
        /// <summary>
        /// Gets the latest weather forecast for the Sydney Region from the BOM.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Weather Forecast.</returns>
        Task<WeatherForecast> GetLatestForecastAsync(CancellationToken cancellationToken = default);
    }
}
