using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherFeed.Australia;
using WeatherFeed.Http.Australia;

namespace WeatherFeed
{
    public static class WeatherFeedExtensions
    {
        public static IServiceCollection AddWeatherFeedServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddAustraliaWeatherServices()
                .AddAustraliaHttpServices();
        }
    }
}
