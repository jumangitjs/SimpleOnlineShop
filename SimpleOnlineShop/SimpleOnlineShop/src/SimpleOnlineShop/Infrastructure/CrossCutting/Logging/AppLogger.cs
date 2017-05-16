using Microsoft.Extensions.Logging;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging
{
    public class AppLogger
    {
        public static ILoggerFactory LoggerFactory { get; set; }
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}