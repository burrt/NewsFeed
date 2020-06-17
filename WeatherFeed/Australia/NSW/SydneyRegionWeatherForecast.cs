using NewsFeed.Data.Weather;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherFeed.Http.Australia;

namespace WeatherFeed.Australia.NSW
{
    /// <summary>
    /// System region weather forecase.
    /// </summary>
    public class SydneyRegionWeatherForecast : ISydneyRegionWeatherForecast
    {
        private IBomAustraliaApiRunner BomAustraliaApiRunner { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SydneyRegionWeatherForecast"/> class.
        /// </summary>
        /// <param name="bomAustraliaApiRunner">BOM Australia API runner.</param>
        public SydneyRegionWeatherForecast(IBomAustraliaApiRunner bomAustraliaApiRunner)
        {
            this.BomAustraliaApiRunner = bomAustraliaApiRunner ?? throw new ArgumentNullException(nameof(bomAustraliaApiRunner));
        }

        /// <inheritdoc />
        public async Task<WeatherForecast> GetLatestForecastAsync(CancellationToken cancellationToken = default)
        {
            var sydneyRegionForecast = await this.BomAustraliaApiRunner.GetLatestSydneyRegionForecastAsync(cancellationToken);
            if (sydneyRegionForecast?.observations?.data == null)
            {
                throw new InvalidOperationException("BOM Sydney Region forecast data is unavailable.");
            }

            var header = sydneyRegionForecast.observations.header.First();
            var weatherForecast = new WeatherForecast
            {
                Id = header.ID,
                LocationInState = header.name,
                LocationState = header.state,
                RefreshMessage = header.refresh_message,
                TimeZone = header.time_zone,
                DayForecasts = new List<DayForecast>(),
            };

            foreach (var dayForecast in sydneyRegionForecast.observations.data)
            {
                weatherForecast.DayForecasts.Add(new DayForecast
                {
                    Location = dayForecast.name,
                    LocalTime = dayForecast.local_date_time,
                    AirTemperature = dayForecast.air_temp,
                    WindDirection = dayForecast.wind_dir,
                    WindSpeedKmHr = dayForecast.wind_spd_kmh,
                });
            }

            return weatherForecast;
        }
    }
}
