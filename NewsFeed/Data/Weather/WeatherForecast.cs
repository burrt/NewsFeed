using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.Weather
{
    /// <summary>
    /// Weather forecast.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public record WeatherForecast
    {
        /// <summary>
        /// Gets weather forecast location ID.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Gets location name within the state of where the weather forecast was made.
        /// </summary>
        public string LocationInState { get; init; }

        /// <summary>
        /// Gets the name of the state for where the weather forecast was made.
        /// </summary>
        public string LocationState { get; init; }

        /// <summary>
        /// Gets message for the weather forecast refresh.
        /// </summary>
        public string RefreshMessage { get; init; }

        /// <summary>
        /// Gets time zone of where the weather forecast was taken.
        /// </summary>
        public string TimeZone { get; init; }

        /// <summary>
        /// Gets list of weather forecasts for the day.
        /// </summary>
        public IList<DayForecast> DayForecasts { get; init; }
    }
}
