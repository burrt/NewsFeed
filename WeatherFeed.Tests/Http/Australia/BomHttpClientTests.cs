using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherFeed.Http.Australia;
using Xunit;

namespace WeatherFeed.Tests.Http.Australia
{
    public class BomHttpClientTests
    {
        private const string AusGovBomProductsUrl = "http://www.bom.gov.au/fwo/";
        private const string RegionId = "123";

        [Fact]
        public async Task GetWeatherForecastAsync_NotSuccessCode_ThrowsInvalidOperationException()
        {
            // Arrange
            var expectedUri = new Uri($"{AusGovBomProductsUrl}{RegionId}.json");
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("{}"),
                })
                .Verifiable();

            // Act
            using var httpClient = new HttpClient(mockHandler.Object);
            {
                var bomHttpClient = new BomHttpClient(httpClient);
                await Assert.ThrowsAsync<InvalidOperationException>(() => bomHttpClient.GetWeatherForecastAsync(RegionId));
            }

            // Assert
            mockHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri == expectedUri),
                    ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetWeatherForecastAsync_ValidHttpResponseMessageContent_Success()
        {
            // Arrange
            var expectedUri = new Uri($"{AusGovBomProductsUrl}{RegionId}.json");
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                })
                .Verifiable();

            // Act
            string responseString;
            using var httpClient = new HttpClient(mockHandler.Object);
            {
                var bomHttpClient = new BomHttpClient(httpClient);
                responseString = await bomHttpClient.GetWeatherForecastAsync(RegionId);
            }

            // Assert
            mockHandler
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri == expectedUri),
                    ItExpr.IsAny<CancellationToken>());
            Assert.Equal("{}", responseString);
        }
    }
}
