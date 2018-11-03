using System;
using System.Globalization;
using System.Linq;
using SpeedTest;
using SpeedTest.Models;
using SpeedTestLogger.Models;

namespace SpeedTestLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SpeedTestLogger!");

            var config = new LoggerConfiguration();
            var runner = new SpeedTestRunner(config.LoggerLocation);
            
            var testData = runner.RunSpeedTest();
            var results = new TestResult
            {
                SessionId = new Guid(),
                User = config.UserId,
                Device = config.LoggerId,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Data = testData
            };


        }


    }
}
