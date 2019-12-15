using Microsoft.Extensions.DependencyInjection;
using System;

namespace NewsFeed
{
    public static class NewsFeedExtensions
    {
        public static IServiceCollection AddNewsFeedServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services;
        }
    }
}
