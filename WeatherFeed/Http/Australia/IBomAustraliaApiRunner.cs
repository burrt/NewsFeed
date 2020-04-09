using System.Threading;
using System.Threading.Tasks;
using NewsFeed.Data.WeatherFeed.Australia.NSW;

namespace WeatherFeed.Http.Australia
{
    /// <summary>
    /// BOM API runner.
    /// </summary>
    public interface IBomAustraliaApiRunner
    {
        /// <summary>
        /// Get the latest Sydney region weather forecast.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>BOM latest weather forecast.</returns>
        Task<BomLatestWeatherForecast> GetLatestSydneyRegionForecastAsync(CancellationToken cancellationToken = default);
    }
}
