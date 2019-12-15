using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Weather.Australia.NSW;
using System;

namespace WeatherFeed.Australia.NSW
{
    internal static class NswWeatherExtensions
    {
        public static IServiceCollection AddNswWeatherServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddTransient<ISydneyRegionWeatherForecast, SydneyRegionWeatherForecast>();
        }
    }
}
