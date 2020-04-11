using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Core;
using NewsFeed.Weather.Australia.NSW;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewsFeed.Cmd
{
    public class Program
    {
        private ILogger Logger { get; set; }
        private IServiceProvider ConsoleServiceProvider { get; }
        private IWeatherForecastConsolePrinter WeatherForecastConsolePrinter { get; }

        public Program(IServiceProvider consoleServiceProvider, IWeatherForecastConsolePrinter weatherForecastConsolePrinter)
        {
            ConsoleServiceProvider = consoleServiceProvider ?? throw new ArgumentNullException(nameof(consoleServiceProvider));
            WeatherForecastConsolePrinter = weatherForecastConsolePrinter ?? throw new ArgumentNullException(nameof(weatherForecastConsolePrinter));
        }

        /// <summary>
        /// Prints the news feed.
        /// </summary>
        /// <param name="sydneyRegionWeatherForecast">Sydney region weather forecast.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task PrintNewsFeedAsync(ISydneyRegionWeatherForecast sydneyRegionWeatherForecast, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(sydneyRegionWeatherForecast, nameof(sydneyRegionWeatherForecast));

            // Sydney Region weather forecast
            var weatherForecast = await sydneyRegionWeatherForecast.GetLatestForecastAsync(cancellationToken);
            if (weatherForecast != null)
            {
                WeatherForecastConsolePrinter.PrintForecast(weatherForecast);
            }
        }

        /// <summary>
        /// Entry point of the command line program.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>Exit code.</returns>
        internal static async Task<int> Main(string[] args)
        {
            var cancellationToken = new CancellationToken();
            var serviceProvider = CreateConsoleServiceProvider();

            PrintToConsoleStartupMessage();

            var consolePrinter = (IWeatherForecastConsolePrinter)serviceProvider.GetService(typeof(IWeatherForecastConsolePrinter));
            var newsFeedProgram = new Program(serviceProvider, consolePrinter);

            var sydneyRegionWeatherForecast = (ISydneyRegionWeatherForecast)newsFeedProgram.ConsoleServiceProvider.GetService(typeof(ISydneyRegionWeatherForecast));
            await newsFeedProgram.PrintNewsFeedAsync(sydneyRegionWeatherForecast, cancellationToken);

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
        /// Create the service provider and register services.
        /// </summary>
        /// <returns>Service provider.</returns>
        private static IServiceProvider CreateConsoleServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddNewsFeedCmdServices();
            serviceCollection.AddLogging();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
