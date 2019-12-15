using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Logging;
using WeatherFeed;
using NewsFeed.Http.Australia.NSW;
using NewsFeed.Weather.Australia.NSW;
using NewsFeed.Cmd.ConsolePrinters.Weather;
using System.Threading.Tasks;

namespace NewsFeed.Cmd
{
    internal class Program
    {
        private ILogger Logger { get; set; }
        private ServiceProvider ConsoleServiceProvider { get; }

        public Program()
        {
            ConsoleServiceProvider = CreateConsoleServiceProvider();
        }

        /// <summary>
        /// Entry point of the command line program.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>Exit code.</returns>
        internal static async Task<int> Main(string[] args)
        {
            PrintToConsoleStartupMessage();

            var cancellationToken = new CancellationToken();

            var newsFeedProgram = new Program();

            // Sydney Region weather forecast
            var sydneyRegionWeatherForecast = (ISydneyRegionWeatherForecast)newsFeedProgram.ConsoleServiceProvider.GetService(typeof(ISydneyRegionWeatherForecast));
            var weatherForecast = await sydneyRegionWeatherForecast.GetLatestForecastAsync(cancellationToken);

            if (weatherForecast != null)
            {
                WeatherForecastConsolePrinter.PrintForecast(weatherForecast);
            }

            PrintToConsoleShutdownMessage();

            return 0;
        }

        /// <summary>
        /// Print startup message.
        /// </summary>
        private static void PrintToConsoleStartupMessage()
        {
            Console.WriteLine("******************************************************************************");
            Console.WriteLine("Starting...");
            Console.WriteLine("******************************************************************************");
        }

        /// <summary>
        /// Print shutdown message.
        /// </summary>
        private static void PrintToConsoleShutdownMessage()
        {
            Console.WriteLine();
            Console.WriteLine("******************************************************************************");
            Console.WriteLine("Exiting...");
            Console.WriteLine("******************************************************************************");
        }

        /// <summary>
        /// Create the service provider.
        /// </summary>
        /// <returns>Service provider.</returns>
        private static ServiceProvider CreateConsoleServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddNewsFeedCmdServices();
            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
