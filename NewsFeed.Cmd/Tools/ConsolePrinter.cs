using NewsFeed.Core;
using System.IO;

namespace NewsFeed.Cmd.Tools
{
    /// <summary>
    /// Console printer.
    /// </summary>
    public class ConsolePrinter : IConsolePrinter
    {
        /// <inheritdoc />
        public void Write(TextWriter outputStream, string value = null)
        {
            Guard.IsNotNull(outputStream, nameof(outputStream));

            outputStream.Write(value);
        }

        /// <inheritdoc />
        public void WriteLine(TextWriter outputStream, string value = null)
        {
            Guard.IsNotNull(outputStream, nameof(outputStream));

            outputStream.WriteLine(value);
        }
    }
}
