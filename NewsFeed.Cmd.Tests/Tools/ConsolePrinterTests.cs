using Moq;
using NewsFeed.Cmd.Tools;
using System;
using System.IO;
using Xunit;

namespace NewsFeed.Cmd.Tests.Tools
{
    public class ConsolePrinterTests
    {
        private Mock<TextWriter> MockTextWriter { get; }
        private IConsolePrinter ConsolePrinter { get; }

        public ConsolePrinterTests()
        {
            MockTextWriter = new Mock<TextWriter>(MockBehavior.Strict);
            MockTextWriter.Setup(s => s.Write(It.IsAny<string>()));
            MockTextWriter.Setup(s => s.WriteLine(It.IsAny<string>()));

            ConsolePrinter = new ConsolePrinter();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Write_NullStream_ThrowsException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => ConsolePrinter.Write(null, value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void WriteLine_NullStream_ThrowsException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => ConsolePrinter.WriteLine(null, value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("foo")]
        [InlineData(null)]
        public void Write_ValidString_Success(string value)
        {
            ConsolePrinter.Write(MockTextWriter.Object, value);

            MockTextWriter.Verify(s => s.Write(value), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("foo")]
        [InlineData(null)]
        public void WriteLine_ValidString_Success(string value)
        {
            ConsolePrinter.WriteLine(MockTextWriter.Object, value);

            MockTextWriter.Verify(s => s.WriteLine(value), Times.Once);
        }
    }
}
