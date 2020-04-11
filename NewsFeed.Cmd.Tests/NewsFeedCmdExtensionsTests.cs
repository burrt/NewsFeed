using System;
using Xunit;

namespace NewsFeed.Cmd.Tests
{
    public class NewsFeedCmdExtensionsTests
    {
        [Fact]
        public void AddNewsFeedCmdServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => NewsFeedCmdExtensions.AddNewsFeedCmdServices(null));
        }
    }
}
