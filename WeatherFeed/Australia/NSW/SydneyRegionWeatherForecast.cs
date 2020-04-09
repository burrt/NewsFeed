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
    public class SydneyRegionWeatherForecast : ISydneyRegionWeatherForecast
    {
        private IBomAustraliaApiRunner BomAustraliaApiRunner { get; }

        public SydneyRegionWeatherForecast(IBomAustraliaApiRunner bomAustraliaApiRunner)
        {
            BomAustraliaApiRunner = bomAustraliaApiRunner ?? throw new ArgumentNullException(nameof(bomAustraliaApiRunner));
        }

        public async Task<WeatherForecast> GetLatestForecastAsync(CancellationToken cancellationToken = default)
        {
            var sydneyRegionForecast = await BomAustraliaApiRunner.GetLatestSydneyRegionForecastAsync(cancellationToken);
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
                DayForecasts = new List<DayForecast>()
            };

            foreach (var dayForecast in sydneyRegionForecast.observations.data)
            {
                weatherForecast.DayForecasts.Add(new DayForecast
                {
                    Location = dayForecast.name,
                    LocalTime = dayForecast.local_date_time,
                    AirTemperature = dayForecast.air_temp,
                    WindDirection = dayForecast.wind_dir,
                    WindSpeedKmHr = dayForecast.wind_spd_kmh
                });
            }

            return weatherForecast;
        }
    }
}
