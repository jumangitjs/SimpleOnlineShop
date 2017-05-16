using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension
{
    public static class AppBuilderExtension
    {
        public static IApplicationBuilder UseAppBuilder(this IApplicationBuilder app, ILoggerFactory factory,
            IEventDispatcher eventDispatcher)
        {
            AppLogger.LoggerFactory = factory;
            DomainEvent.Dispatcher = eventDispatcher;
            return app;
        }
    }
}