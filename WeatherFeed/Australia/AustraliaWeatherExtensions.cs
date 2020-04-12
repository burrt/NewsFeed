using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;
using WeatherFeed.Australia.NSW;

namespace WeatherFeed.Australia
{
    [ExcludeFromCodeCoverage]
    public static class AustraliaWeatherExtensions
    {
        public static IServiceCollection AddAustraliaWeatherServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddNswWeatherServices();
        }
    }
}
