using Microsoft.Extensions.Logging;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events.CustomerEvents
{
    public class CustomerEmailChangedEventHandler : IDomainEventHandler<UserEmailChanged>
    {
        public void HandleEvent(UserEmailChanged @event)
        {
            var log = AppLogger.CreateLogger<CustomerEmailChangedEventHandler>();

            log.LogInformation(
                "User with id {User} email changed from {OldEmail} to {NewEmail}",
                @event.CustomerId, @event.OldEmail, @event.NewEmail
            );
        }
    }

    public class CustomerContactNoChangedEventHandler : IDomainEventHandler<UserContactNoChanged>
    {
        public void HandleEvent(UserContactNoChanged @event)
        {
            var log = AppLogger.CreateLogger<CustomerContactNoChangedEventHandler>();

            log.LogInformation(
                "User with id {UserId} contact number changed from {OldContactNo} to {NewContactNo}",
                @event.CustomerId, @event.OldContactNo, @event.NewContactNo);
        }
    }

    public class CustomerCreatedEventHandler : IDomainEventHandler<UserCreated>
    {
        public void HandleEvent(UserCreated @event)
        {
            var log = AppLogger.CreateLogger<CustomerCreatedEventHandler>();

            log.LogInformation(
                "User created, data as follows: {User}", @event.User);
        }
    }

    public class CustomerAddedOrderHandler : IDomainEventHandler<UserAddedOrder>
    {
        public void HandleEvent(UserAddedOrder @event)
        {
            var log = AppLogger.CreateLogger<UserAddedOrder>();

            log.LogInformation(
                "User added an order, data as follows: {Order}", @event.Order);
        }
    }
}