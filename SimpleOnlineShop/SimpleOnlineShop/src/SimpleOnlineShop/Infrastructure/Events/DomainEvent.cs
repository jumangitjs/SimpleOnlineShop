using SimpleOnlineShop.SimpleOnlineShop.Domain;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events
{
    public class DomainEvent : IDomainEvent
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            Dispatcher?.Dispatch(@event);
        }
    }
}