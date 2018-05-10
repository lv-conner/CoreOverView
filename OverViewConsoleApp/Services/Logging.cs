using System;
using System.Collections.Generic;
using System.Text;
using Concos.Logging.Extension.FileLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace OverViewConsoleApp.Services
{
    public class Logging
    {
        public static void TestLogProvider()
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Logging");
            logger.LogInformation("Hello Word");

            Console.ReadLine();
        }

        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection().AddLogging(options =>
            {
                options.AddFileLogger();
            });
            services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());
            return services.BuildServiceProvider();
        }

        public static void GetService()
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
        }
    }
}
