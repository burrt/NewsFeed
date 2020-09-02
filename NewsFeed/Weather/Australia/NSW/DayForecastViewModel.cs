using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Weather.Australia.NSW
{
    /// <summary>
    /// Sydney day weather forecast view model.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DayForecastViewModel
    {
        /// <summary>
        /// Gets or sets location of the weather forecast.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets format is in DD/HH:MM:(am/pm) - not a standard format.
        /// </summary>
        public string LocalTime { get; set; }

        /// <summary>
        /// Gets or sets air temperature in degrees celsius.
        /// </summary>
        public double? AirTemperature { get; set; }

        /// <summary>
        /// Gets or sets current wind direction.
        /// </summary>
        public string WindDirection { get; set; }

        /// <summary>
        /// Gets or sets wind speed in km/hr.
        /// </summary>
        public int? WindSpeedKmHr { get; set; }
    }
}
