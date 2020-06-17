using System;
using WeatherFeed.Australia.NSW;
using Xunit;

namespace WeatherFeed.Tests.Australia.NSW
{
    /// <summary>
    /// NSW Weather Extensions tests.
    /// </summary>
    public class NswWeatherExtensionsTests
    {
        /// <summary>
        /// Throws exception if services is null.
        /// </summary>
        [Fact]
        public void NswWeatherExtensions_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => NswWeatherExtensions.AddNswWeatherServices(null));
        }
    }
}
