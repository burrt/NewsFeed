using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherFeed.Australia.NSW;

namespace WeatherFeed.Australia
{
    internal static class AustraliaWeatherExtensions
    {
        public static IServiceCollection AddAustraliaWeatherServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddNswWeatherServices();
        }
    }
}
