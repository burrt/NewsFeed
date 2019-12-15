using System.Collections.Generic;

namespace NewsFeed.Data.Weather
{
    /// <summary>
    /// Weather forecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Weather forecast location ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Location name within the state of where the weather forecast was made.
        /// </summary>
        public string LocationInState { get; set; }

        /// <summary>
        /// The name of the state for where the weather forecast was made.
        /// </summary>
        public string LocationState { get; set; }

        /// <summary>
        /// Message for the weather forecast refresh.
        /// </summary>
        public string RefreshMessage { get; set; }

        /// <summary>
        /// Time zone of where the weather forecast was taken.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// List of weather forecasts for the day.
        /// </summary>
        public IList<DayForecast> DayForecasts { get; set; }
    }
}
