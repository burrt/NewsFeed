using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Weather.Australia.NSW
{
    /// <summary>
    /// Sydney weather forecast view model.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WeatherForecastViewModel
    {
        /// <summary>
        /// Gets or sets weather forecast location ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets location name within the state of where the weather forecast was made.
        /// </summary>
        public string LocationInState { get; set; }

        /// <summary>
        /// Gets or sets the name of the state for where the weather forecast was made.
        /// </summary>
        public string LocationState { get; set; }

        /// <summary>
        /// Gets or sets message for the weather forecast refresh.
        /// </summary>
        public string RefreshMessage { get; set; }

        /// <summary>
        /// Gets or sets time zone of where the weather forecast was taken.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets list of weather forecasts for the day.
        /// </summary>
        public IList<DayForecastViewModel> DayForecasts { get; set; }
    }
}
