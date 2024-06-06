using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public record BomData
    {
#pragma warning disable IDE1006
#pragma warning disable SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// Gets sort order.
        /// </summary>
        public int sort_order { get; init; }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string name { get; init; }

        /// <summary>
        /// Gets local date time.
        /// </summary>
        public string local_date_time { get; init; }

        /// <summary>
        /// Gets time UTC.
        /// </summary>
        public long aifstime_utc { get; init; }

        /// <summary>
        /// Gets air temperature in degrees celsius.
        /// </summary>
        public double air_temp { get; init; }

        /// <summary>
        /// Gets wind direction.
        /// </summary>
        public string wind_dir { get; init; }

        /// <summary>
        /// Gets wind speed (km/h).
        /// </summary>
        public int? wind_spd_kmh { get; init; }

#pragma warning restore IDE1006
#pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
