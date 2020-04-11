using System;
using WeatherFeed.Http.Australia;
using Xunit;

namespace WeatherFeed.Tests.Http.Australia
{
    public class AustraliaHttpExtensionsTests
    {
        [Fact]
        public void AddAustraliaHttpServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => AustraliaHttpExtensions.AddAustraliaHttpServices(null));
        }
    }
}
