using System;
using Xunit;

namespace WeatherFeed.Tests
{
    public class WeatherFeedExtensionsTests
    {
        [Fact]
        public void AddWeatherFeedServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => WeatherFeedExtensions.AddWeatherFeedServices(null));
        }
    }
}
