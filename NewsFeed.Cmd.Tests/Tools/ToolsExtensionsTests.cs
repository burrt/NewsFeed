using NewsFeed.Cmd.Tools;
using System;
using Xunit;

namespace NewsFeed.Cmd.Tests.Tools
{
    public class ToolsExtensionsTests
    {
        [Fact]
        public void AddToolsServices_NullServices_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => ToolsExtensions.AddToolsServices(null));
        }
    }
}
