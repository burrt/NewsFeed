using Moq;
using System.Threading;
using System.Threading.Tasks;
using WeatherFeed.Http.Australia;
using Xunit;

namespace WeatherFeed.Tests.Http.Australia
{
    /// <summary>
    /// BOM Australia API runner tests.
    /// </summary>
    public class BomAustraliaApiRunnerTests
    {
        private const string SydneyRegionId = "IDN60901/IDN60901.94768";

        private Mock<BomHttpClient> MockBomHttpClient { get; }

        private BomAustraliaApiRunner BomAustraliaApiRunner { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BomAustraliaApiRunnerTests"/> class.
        /// </summary>
        public BomAustraliaApiRunnerTests()
        {
            this.MockBomHttpClient = new Mock<BomHttpClient>();
            this.BomAustraliaApiRunner = new BomAustraliaApiRunner(this.MockBomHttpClient.Object);
        }

        /// <summary>
        /// GetWeatherForecastAsync returns null HTTP response when API returns null or whitespace .
        /// </summary>
        /// <param name="httpResponse">HTTP response.</param>
        /// <returns>Task.</returns>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task GetLatestSydneyRegionForecastAsync_NullWhitespaceHttpResponse_ReturnsNull(string httpResponse)
        {
            this.MockBomHttpClient
                .Setup(h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(httpResponse);

            var bomData = await this.BomAustraliaApiRunner.GetLatestSydneyRegionForecastAsync();

            this.MockBomHttpClient.Verify(
                h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()),
                Times.Once);
            Assert.Null(bomData);
        }

        /// <summary>
        /// GetWeatherForecastAsync returns empty HTTP response when API returns empty.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestSydneyRegionForecastAsync_EmptyHttpResponse_Success()
        {
            this.MockBomHttpClient
                .Setup(h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync("{}");

            var bomData = await this.BomAustraliaApiRunner.GetLatestSydneyRegionForecastAsync();

            this.MockBomHttpClient.Verify(
                h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()),
                Times.Once);
            Assert.NotNull(bomData);
        }

        /// <summary>
        /// GetLatestSydneyRegionForecastAsyn returns valid HTTP response when API returns valid data.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetLatestSydneyRegionForecastAsync_ValidHttpResponse_Success()
        {
            this.MockBomHttpClient
                .Setup(h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(@"
{
    ""observations"": {
        ""notice"": [
            {
                ""copyright"": ""Copyright Commonwealth of Australia 2020, Bureau of Meteorology. For more information see: http://www.bom.gov.au/other/copyright.shtml http://www.bom.gov.au/other/disclaimer.shtml"",
                ""copyright_url"": ""http://www.bom.gov.au/other/copyright.shtml"",
                ""disclaimer_url"": ""http://www.bom.gov.au/other/disclaimer.shtml"",
                ""feedback_url"": ""http://www.bom.gov.au/other/feedback""
            }
        ],
        ""header"": [
            {
                ""refresh_message"": ""Issued at  9:51 pm EST Thursday  9 April 2020"",
                ""ID"": ""IDN60901"",
                ""main_ID"": ""IDN60900"",
                ""name"": ""Sydney - Observatory Hill"",
                ""state_time_zone"": ""NSW"",
                ""time_zone"": ""EST"",
                ""product_name"": ""Capital City Observations"",
                ""state"": ""New South Wales""
            }
        ],
        ""data"": [
            {
                ""sort_order"": 0,
                ""wmo"": 94768,
                ""name"": ""Sydney - Observatory Hill"",
                ""history_product"": ""IDN60901"",
                ""local_date_time"": ""09/09:30pm"",
                ""local_date_time_full"": ""20200409213000"",
                ""aifstime_utc"": ""20200409113000"",
                ""lat"": -33.9,
                ""lon"": 151.2,
                ""apparent_t"": 20.2,
                ""cloud"": ""-"",
                ""cloud_base_m"": null,
                ""cloud_oktas"": null,
                ""cloud_type_id"": null,
                ""cloud_type"": ""-"",
                ""delta_t"": 2.1,
                ""gust_kmh"": null,
                ""gust_kt"": null,
                ""air_temp"": 18.8,
                ""dewpt"": 15.3,
                ""press"": 1024.8,
                ""press_qnh"": 1024.9,
                ""press_msl"": 1024.8,
                ""press_tend"": ""-"",
                ""rain_trace"": ""0.0"",
                ""rel_hum"": 80,
                ""sea_state"": ""-"",
                ""swell_dir_worded"": ""-"",
                ""swell_height"": null,
                ""swell_period"": null,
                ""vis_km"": ""-"",
                ""weather"": ""-"",
                ""wind_dir"": ""N"",
                ""wind_spd_kmh"": 2,
                ""wind_spd_kt"": 1
            }
        ]
    }
}");

            var bomData = await this.BomAustraliaApiRunner.GetLatestSydneyRegionForecastAsync();

            this.MockBomHttpClient.Verify(
                h => h.GetWeatherForecastAsync(SydneyRegionId, It.IsAny<CancellationToken>()),
                Times.Once);
            Assert.NotNull(bomData);
            Assert.Equal("IDN60901", bomData.observations.header[0].ID);
            Assert.Equal("Sydney - Observatory Hill", bomData.observations.data[0].name);
            Assert.Equal(18.8, bomData.observations.data[0].air_temp);
            Assert.Equal(2, bomData.observations.data[0].wind_spd_kmh);
        }
    }
}
