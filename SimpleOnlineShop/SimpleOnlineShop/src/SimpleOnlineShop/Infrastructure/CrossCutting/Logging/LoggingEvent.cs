using Microsoft.Extensions.Logging;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging
{
    public class LoggingEvent
    {
        public static EventId CustomerCreated = 1000;
        public static EventId CustomerEmailChanged = 1001;
        public static EventId CustomerContactNumberChange = 1002;
    }
}