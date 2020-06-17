using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM latest weather forecast.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BomLatestWeatherForecast
    {
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// Gets or sets observations.
        /// </summary>
        public BomObservations observations { get; set; }

#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
