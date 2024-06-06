using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.Weather
{
    /// <summary>
    /// Day weather forecast.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public record DayForecast
    {
        /// <summary>
        /// Gets location of the weather forecast.
        /// </summary>
        public string Location { get; init; }

        /// <summary>
        /// Gets format is in DD/HH:MM:(am/pm) - not a standard format.
        /// </summary>
        public string LocalTime { get; init; }

        /// <summary>
        /// Gets air temperature in degrees celsius.
        /// </summary>
        public double AirTemperature { get; init; }

        /// <summary>
        /// Gets current wind direction.
        /// </summary>
        public string WindDirection { get; init; }

        /// <summary>
        /// Gets wind speed in km/hr.
        /// </summary>
        public int? WindSpeedKmHr { get; init; }
    }
}
