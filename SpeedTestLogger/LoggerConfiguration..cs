using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpeedTestLogger
{
    public class LoggerConfiguration
    {
        public readonly string UserId;
        public readonly int LoggerId;
        public readonly RegionInfo LoggerLocation;
        public readonly Uri ApiUrl;
        public readonly ServiceBusConfiguration ServiceBus;

        public LoggerConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json",true);

            var configuration = builder.Build();

            UserId = configuration["userId"];
            LoggerLocation = new RegionInfo(configuration["loggerLocationCountryCode"]);
            LoggerId = Int32.Parse(configuration["loggerId"]);
            ApiUrl = new Uri(configuration["speedTestApiUrl"]);

            ServiceBus = new ServiceBusConfiguration(configuration);

            Console.WriteLine("Logger located in {0}", LoggerLocation.EnglishName);

        }
    }

    public class ServiceBusConfiguration
    {
        public readonly string ConnectionString;
        public readonly string TopicName;
        public readonly string SubscriptionName;

        public ServiceBusConfiguration(IConfigurationRoot configuration)
        {
            ConnectionString = configuration["serviceBus:connectionString"];
            TopicName = configuration["serviceBus:topicName"];
            SubscriptionName = configuration["serviceBus:subscriptionName"];
        }
    }
}