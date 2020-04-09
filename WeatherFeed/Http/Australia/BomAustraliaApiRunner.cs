using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewsFeed.Data.WeatherFeed.Australia.NSW;

namespace WeatherFeed.Http.Australia
{
    public class BomAustraliaApiRunner : IBomAustraliaApiRunner
    {
        private const string SydneyRegionId = "IDN60901/IDN60901.94768";
        private BomHttpClient BomHttpClient { get; }

        public BomAustraliaApiRunner(BomHttpClient bomHttpClient)
        {
            BomHttpClient = bomHttpClient ?? throw new ArgumentNullException(nameof(bomHttpClient));
        }

        public async Task<BomLatestWeatherForecast> GetLatestSydneyRegionForecastAsync(CancellationToken cancellationToken = default)
        {
            var stringResponse = await BomHttpClient.GetWeatherForecastAsync(SydneyRegionId, cancellationToken);

            // Ignore any missing members in the POCOs
            return string.IsNullOrWhiteSpace(stringResponse) ? null : JsonConvert.DeserializeObject<BomLatestWeatherForecast>(stringResponse, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
