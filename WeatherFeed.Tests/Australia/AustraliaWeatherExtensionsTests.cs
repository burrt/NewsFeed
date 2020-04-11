using System;
using WeatherFeed.Australia;
using Xunit;

namespace WeatherFeed.Tests.Australia
{
    public class AustraliaWeatherExtensionsTests
    {
        [Fact]
        public void AddAustraliaWeatherServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => AustraliaWeatherExtensions.AddAustraliaWeatherServices(null));
        }
    }
}
