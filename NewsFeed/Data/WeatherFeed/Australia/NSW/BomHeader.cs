using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM Header.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BomHeader
    {
#pragma warning disable SA1300 // Element should begin with upper-case letter
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// Gets or sets refresh message.
        /// </summary>
        public string refresh_message { get; set; }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets main ID.
        /// </summary>
        public string main_ID { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets state time zone.
        /// </summary>
        public string state_time_zone { get; set; }

        /// <summary>
        /// Gets or sets time zone.
        /// </summary>
        public string time_zone { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string product_name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string state { get; set; }

#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore IDE1006 // Naming Styles
    }
}
