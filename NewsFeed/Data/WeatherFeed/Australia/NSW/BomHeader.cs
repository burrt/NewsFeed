using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM Header.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public record BomHeader
    {
#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// Gets refresh message.
        /// </summary>
        public string refresh_message { get; init; }

        /// <summary>
        /// Gets ID.
        /// </summary>
        public string ID { get; init; }

        /// <summary>
        /// Gets main ID.
        /// </summary>
        public string main_ID { get; init; }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string name { get; init; }

        /// <summary>
        /// Gets state time zone.
        /// </summary>
        public string state_time_zone { get; init; }

        /// <summary>
        /// Gets time zone.
        /// </summary>
        public string time_zone { get; init; }

        /// <summary>
        /// Gets product name.
        /// </summary>
        public string product_name { get; init; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public string state { get; init; }

#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore IDE1006 // Naming Styles
    }
}
