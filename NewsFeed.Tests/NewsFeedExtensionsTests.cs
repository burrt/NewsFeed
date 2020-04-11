using System;
using Xunit;

namespace NewsFeed.Tests
{
    public class NewsFeedExtensionsTests
    {
        [Fact]
        public void AddNewsFeedServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => NewsFeedExtensions.AddNewsFeedServices(null));
        }
    }
}
