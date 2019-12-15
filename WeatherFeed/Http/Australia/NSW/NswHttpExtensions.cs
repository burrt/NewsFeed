using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Http.Australia.NSW;
using System;
using System.Net.Http;

namespace WeatherFeed.Http.Australia.NSW
{
    internal static class NswHttpExtensions
    {
        internal static IServiceCollection AddNswHttpServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Add typed HTTP clients
            services.AddHttpClient<IBomSydneyRegionApiRunner, BomSydneyRegionApiRunner>();

            return services;
        }
    }
}
