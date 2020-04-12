using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.Weather
{
    /// <summary>
    /// Day weather forecast.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DayForecast
    {
        /// <summary>
        /// Location of the weather forecast.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Format is in DD/HH:MM:(am/pm) - not a standard format.
        /// </summary>
        public string LocalTime { get; set; }

        /// <summary>
        /// Air temperature in degrees celsius.
        /// </summary>
        public double AirTemperature { get; set; }

        /// <summary>
        /// Current wind direction.
        /// </summary>
        public string WindDirection { get; set; }

        /// <summary>
        /// Wind speed in km/hr.
        /// </summary>
        public int WindSpeedKmHr { get; set; }
    }
}
