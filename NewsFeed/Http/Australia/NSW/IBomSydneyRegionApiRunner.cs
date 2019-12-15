using NewsFeed.Data.Australia.NSW;
using System.Threading;
using System.Threading.Tasks;

namespace NewsFeed.Http.Australia.NSW
{
    /// <summary>
    /// Interface for the HTTP API client for obtaining the Sydney Region weather forecast from the BOM.
    /// </summary>
    public interface IBomSydneyRegionApiRunner
    {
        /// <summary>
        /// Gets the latest weather forecast for the Sydney Region from the BOM API.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Latest Weather Forecast.</returns>
        Task<BomLatestWeatherForecast> GetLatestSydneyRegionForecastAsync(CancellationToken cancellationToken = default);
    }
}
