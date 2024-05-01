using System;
using NewsFeed.Core;
using Xunit;


namespace NewsFeed.Tests.Core
{
    /// <summary>
    /// Guard tests.
    /// </summary>
    public class GuardTests
    {
        /// <summary>
        /// IsNotNull throws exception for null object.
        /// </summary>
        [Fact]
        public void IsNotNull_NullObject_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(null, null));
        }

        /// <summary>
        /// IsNotNull for valid objects does nothing.
        /// </summary>
        [Fact]
        public void IsNotNull_ValidObject_Success()
        {
            Guard.IsNotNull(new object(), "object");
        }
    }
}
