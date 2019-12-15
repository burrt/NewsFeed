using NewsFeed.Data.Australia.NSW;
using NewsFeed.Http.Australia.NSW;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherFeed.Http.Australia.NSW
{
    /// <summary>
    /// HTTP API client runner for the BOM Sydney Region weather forecast.
    /// </summary>
    public class BomSydneyRegionApiRunner : BomAustraliaApiRunnerBase, IBomSydneyRegionApiRunner
    {
        private const string SydneyRegionId = "IDN60901/IDN60901.94768";
        public HttpClient BomApiClient { get; }

        public BomSydneyRegionApiRunner(HttpClient httpClient)
        {
            BomApiClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            BomApiClient.BaseAddress = new Uri(AusGovBomProductsUrl);
            BomApiClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <inheritdoc />
        public async Task<BomLatestWeatherForecast> GetLatestSydneyRegionForecastAsync(CancellationToken cancellationToken = default)
        {
            var httpResponseMessage = await BomApiClient.GetAsync($"{SydneyRegionId}.json", cancellationToken);

            if (httpResponseMessage?.Content == null)
            {
                throw new InvalidOperationException($"No data from BOM API: {BomApiClient.BaseAddress}{SydneyRegionId}");
            }

            // Ignore any missing members in the POCOs
            var stringResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            return string.IsNullOrWhiteSpace(stringResponse) ? null : JsonConvert.DeserializeObject<BomLatestWeatherForecast>(stringResponse, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
