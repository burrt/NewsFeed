using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsFeed.Core;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Weather
{
    /// <summary>
    /// Weather forecast controller.
    /// </summary>
    public class WeatherController : ApiVersion1Controller
    {
        private ISydneyRegionWeatherForecast SydneyRegionWeatherForecast { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherController"/> class.
        /// </summary>
        /// <param name="sydneyRegionWeatherForecast">Sydney region weather forecast.</param>
        public WeatherController(ISydneyRegionWeatherForecast sydneyRegionWeatherForecast)
        {
            this.SydneyRegionWeatherForecast = sydneyRegionWeatherForecast ?? throw new ArgumentNullException(nameof(sydneyRegionWeatherForecast));
        }

        /// <summary>
        /// Get the Sydney weather forecast.
        /// </summary>
        /// <returns><see cref="IActionResult"/>.</returns>
        [HttpGet("Australia/Nsw/Sydney")]
        [ProducesResponseType(typeof(WeatherForecastViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSydneyForecast()
        {
            var forecast = await this.SydneyRegionWeatherForecast.GetLatestForecastAsync();
            var viewModel = new WeatherForecastViewModel()
            {
                Id = forecast.Id,
                LocationInState = forecast.LocationInState,
                LocationState = forecast.LocationState,
                TimeZone = forecast.TimeZone,
                RefreshMessage = forecast.RefreshMessage,
                DayForecasts = forecast.DayForecasts.Select(d => new DayForecastViewModel()
                {
                    Location = d.Location,
                    LocalTime = d.LocalTime,
                    AirTemperature = d.AirTemperature,
                    WindDirection = d.WindDirection,
                    WindSpeedKmHr = d.WindSpeedKmHr,
                }).ToList(),
            };
            return Ok(viewModel);
        }
    }
}
