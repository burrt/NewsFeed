using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherFeed.Http.Australia
{
    /// <summary>
    /// BOM HTTP client.
    /// </summary>
    public class BomHttpClient : IBomHttpClient
    {
        private const string AusGovBomProductsUrl = "http://www.bom.gov.au/fwo/";

        private HttpClient HttpClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BomHttpClient"/> class for unit testing.
        /// </summary>
        public BomHttpClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BomHttpClient"/> class.
        /// HTTP client will be injected using IHttpClientFactory.
        /// </summary>
        /// <param name="httpClient">HTTP client.</param>
        public BomHttpClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            this.HttpClient.BaseAddress = new Uri(AusGovBomProductsUrl);
            this.HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <inheritdoc />
        public virtual async Task<string> GetWeatherForecastAsync(string sydneyRegionId, CancellationToken cancellationToken = default)
        {
            var httpResponseMessage = await this.HttpClient.GetAsync($"{sydneyRegionId}.json", cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"BOM API returned no success exit code: {httpResponseMessage.StatusCode}, content: {httpResponseMessage.Content}");
            }

            return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
