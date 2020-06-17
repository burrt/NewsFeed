using NewsFeed.Data.WeatherFeed.Australia.NSW;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherFeed.Http.Australia
{
    /// <summary>
    /// BOM Australia API runner.
    /// </summary>
    public class BomAustraliaApiRunner : IBomAustraliaApiRunner
    {
        private const string SydneyRegionId = "IDN60901/IDN60901.94768";

        private BomHttpClient BomHttpClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BomAustraliaApiRunner"/> class.
        /// </summary>
        /// <param name="bomHttpClient">BOM HTTP client.</param>
        public BomAustraliaApiRunner(BomHttpClient bomHttpClient)
        {
            this.BomHttpClient = bomHttpClient ?? throw new ArgumentNullException(nameof(bomHttpClient));
        }

        /// <inheritdoc />
        public async Task<BomLatestWeatherForecast> GetLatestSydneyRegionForecastAsync(CancellationToken cancellationToken = default)
        {
            var stringResponse = await this.BomHttpClient.GetWeatherForecastAsync(SydneyRegionId, cancellationToken);

            // Ignore any missing members in the POCOs
            return string.IsNullOrWhiteSpace(stringResponse) ? null : JsonConvert.DeserializeObject<BomLatestWeatherForecast>(stringResponse, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
            });
        }
    }
}
