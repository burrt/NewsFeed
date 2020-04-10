using System.IO;

namespace NewsFeed.Cmd.Tools
{
    /// <summary>
    /// Interface for printing to the console.
    /// </summary>
    public interface IConsolePrinter
    {
        /// <summary>
        /// Write to the console.
        /// </summary>
        /// <param name="outputStream">Stream to write to.</param>
        /// <param name="value">Value to write out.</param>
        void Write(TextWriter outputStream, string value = null);

        /// <summary>
        /// Write with new line to the console.
        /// </summary>
        /// <param name="outputStream">Stream to write to.</param>
        /// <param name="value">Value to write out.</param>
        void WriteLine(TextWriter outputStream, string value = null);
    }
}
