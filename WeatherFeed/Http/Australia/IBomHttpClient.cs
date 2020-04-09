using System.Threading;
using System.Threading.Tasks;

namespace WeatherFeed.Http.Australia
{
    /// <summary>
    /// Australia BOM HTTP client.
    /// </summary>
    public interface IBomHttpClient
    {
        /// <summary>
        /// Get the weather forecast as a JSON string.
        /// </summary>
        /// <param name="sydneyRegionId">Sydney region ID.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>JSON string of the weather forecast.</returns>
        Task<string> GetWeatherForecastAsync(string sydneyRegionId, CancellationToken cancellationToken = default);
    }
}
