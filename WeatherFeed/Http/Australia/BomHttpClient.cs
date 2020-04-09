using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherFeed.Http.Australia
{
    public class BomHttpClient : IBomHttpClient
    {
        private const string AusGovBomProductsUrl = "http://www.bom.gov.au/fwo/";
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Testing purposes.
        /// </summary>
        public BomHttpClient()
        {
        }

        /// <summary>
        /// HTTP client will be injected using IHttpClientFactory.
        /// </summary>
        /// <param name="httpClient"></param>
        public BomHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            HttpClient.BaseAddress = new Uri(AusGovBomProductsUrl);
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public virtual async Task<string> GetWeatherForecastAsync(string sydneyRegionId, CancellationToken cancellationToken = default)
        {
            var httpResponseMessage = await HttpClient.GetAsync($"{sydneyRegionId}.json", cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"BOM API returned no success exit code: {httpResponseMessage.StatusCode}, content: {httpResponseMessage.Content}");
            }

            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
