using System;
using System.IO;
using Moq;
using NewsFeed.Cmd.Tools;
using Xunit;

namespace NewsFeed.Cmd.Tests.Tools
{
    /// <summary>
    /// Console printer tests.
    /// </summary>
    public class ConsolePrinterTests
    {
        private Mock<TextWriter> MockTextWriter { get; }

        private ConsolePrinter ConsolePrinter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsolePrinterTests"/> class.
        /// </summary>
        public ConsolePrinterTests()
        {
            this.MockTextWriter = new Mock<TextWriter>(MockBehavior.Strict);
            this.MockTextWriter.Setup(s => s.Write(It.IsAny<string>()));
            this.MockTextWriter.Setup(s => s.WriteLine(It.IsAny<string>()));

            this.ConsolePrinter = new ConsolePrinter();
        }

        /// <summary>
        /// Write with a null stream throws exception.
        /// </summary>
        /// <param name="value">String values to write.</param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Write_NullStream_ThrowsException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => this.ConsolePrinter.Write(null, value));
        }

        /// <summary>
        /// WriteLine with a null stream throws exception.
        /// </summary>
        /// <param name="value">String values to write.</param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void WriteLine_NullStream_ThrowsException(string value)
        {
            Assert.Throws<ArgumentNullException>(() => this.ConsolePrinter.WriteLine(null, value));
        }

        /// <summary>
        /// Write with valid strings are successful.
        /// </summary>
        /// <param name="value">String values to write.</param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("foo")]
        [InlineData(null)]
        public void Write_ValidString_Success(string value)
        {
            this.ConsolePrinter.Write(this.MockTextWriter.Object, value);

            this.MockTextWriter.Verify(s => s.Write(value), Times.Once);
        }

        /// <summary>
        /// WriteLine with valid strings are successful.
        /// </summary>
        /// <param name="value">String values to write.</param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("foo")]
        [InlineData(null)]
        public void WriteLine_ValidString_Success(string value)
        {
            this.ConsolePrinter.WriteLine(this.MockTextWriter.Object, value);

            this.MockTextWriter.Verify(s => s.WriteLine(value), Times.Once);
        }
    }
}
