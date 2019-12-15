using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherFeed.Http.Australia.NSW;

namespace WeatherFeed.Http.Australia
{
    internal static class AustraliaHttpExtensions
    {
        internal static IServiceCollection AddAustraliaHttpServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services
                .AddNswHttpServices();
        }
    }
}
