using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BomData
    {
#pragma warning disable IDE1006
#pragma warning disable SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// Gets or sets sort order.
        /// </summary>
        public int sort_order { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets local date time.
        /// </summary>
        public string local_date_time { get; set; }

        /// <summary>
        /// Gets or sets time UTC.
        /// </summary>
        public long aifstime_utc { get; set; }

        /// <summary>
        /// Gets or sets air temperature in degrees celcius.
        /// </summary>
        public double air_temp { get; set; }

        /// <summary>
        /// Gets or sets wind direction.
        /// </summary>
        public string wind_dir { get; set; }

        /// <summary>
        /// Gets or sets wind speed (km/h).
        /// </summary>
        public int? wind_spd_kmh { get; set; }

#pragma warning restore IDE1006
#pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
