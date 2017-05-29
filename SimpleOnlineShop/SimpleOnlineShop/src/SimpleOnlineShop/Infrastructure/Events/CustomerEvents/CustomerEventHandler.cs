using Microsoft.Extensions.Logging;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events.CustomerEvents
{
    public class UserEmailChangedEventHandler : IDomainEventHandler<UserEmailChanged>
    {
        public void HandleEvent(UserEmailChanged @event)
        {
            var log = AppLogger.CreateLogger<UserEmailChangedEventHandler>();

            log.LogInformation(
                "User with id {User} email changed from {OldEmail} to {NewEmail}",
                @event.CustomerId, @event.OldEmail, @event.NewEmail
            );
        }
    }

    public class UserContactNoChangedEventHandler : IDomainEventHandler<UserContactNoChanged>
    {
        public void HandleEvent(UserContactNoChanged @event)
        {
            var log = AppLogger.CreateLogger<UserContactNoChangedEventHandler>();

            log.LogInformation(
                "User with id {UserId} contact number changed from {OldContactNo} to {NewContactNo}",
                @event.CustomerId, @event.OldContactNo, @event.NewContactNo);
        }
    }

    public class UserCreatedEventHandler : IDomainEventHandler<UserCreated>
    {
        public void HandleEvent(UserCreated @event)
        {
            var log = AppLogger.CreateLogger<UserCreatedEventHandler>();

            log.LogInformation(
                "User created, data as follows: {User}", @event.User);
        }
    }

    public class UserAddedOrderHandler : IDomainEventHandler<UserAddedOrder>
    {
        public void HandleEvent(UserAddedOrder @event)
        {
            var log = AppLogger.CreateLogger<UserAddedOrder>();

            log.LogInformation(
                "User added an order, data as follows: {Order}", @event.Order);
        }
    }

    public class CustomerCheckout : IDomainEventHandler<UserCheckout>
    {
        public void HandleEvent(UserCheckout @event)
        {
            var log = AppLogger.CreateLogger<UserCheckout>();

            log.LogInformation(
                "User checked out, data as follows: {Checkout}, {GrandTotal}", @event.Orders, @event.GrandTotal);
        }
    }
}