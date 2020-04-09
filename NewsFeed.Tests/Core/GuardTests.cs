using System;
using NewsFeed.Core;
using Xunit;

namespace NewsFeed.Tests.Core
{
    public class GuardTests
    {
        [Fact]
        public void IsNotNull_NullObject_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(null, null));
        }

        [Fact]
        public void IsNotNull_ValidObject_Success()
        {
            Guard.IsNotNull(new object(), "object");
        }
    }
}
