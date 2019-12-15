using System.Threading;
using System.Threading.Tasks;

namespace NewsFeed.Http.Australia.NSW
{
    /// <summary>
    /// Interface for the HTTP API client for obtaining the NSW Region weather forecast from the BOM.
    /// </summary>
    public interface IBomNswApiRunner : IBomSydneyRegionApiRunner
    {
        /// <summary>
        /// Get latest NSW Region weather forecast.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task GetLatestNswForecastAsync(CancellationToken cancellationToken = default);
    }
}
