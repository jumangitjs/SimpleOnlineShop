using SimpleOnlineShop.SimpleOnlineShop.Domain;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
    }
}