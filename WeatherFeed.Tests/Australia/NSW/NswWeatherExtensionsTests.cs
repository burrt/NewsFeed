using System;
using WeatherFeed.Australia.NSW;
using Xunit;

namespace WeatherFeed.Tests.Australia.NSW
{
    public class NswWeatherExtensionsTests
    {
        [Fact]
        public void NswWeatherExtensions_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => NswWeatherExtensions.AddNswWeatherServices(null));
        }
    }
}
