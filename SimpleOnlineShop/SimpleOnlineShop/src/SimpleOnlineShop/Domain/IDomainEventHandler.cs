using SimpleOnlineShop.SimpleOnlineShop.Domain;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events
{
    public interface IDomainEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        void HandleEvent(TEvent @event);
    }
}