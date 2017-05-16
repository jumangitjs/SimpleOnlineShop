using Microsoft.Extensions.Logging;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Logging;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events.CustomerEvents
{
    public class CustomerEmailChangedEventHandler : IDomainEventHandler<CustomerEmailChanged>
    {
        public void HandleEvent(CustomerEmailChanged @event)
        {
            var log = AppLogger.CreateLogger<CustomerEmailChangedEventHandler>();

            log.LogInformation(
                "Customer with id {Customer} email changed from {OldEmail} to {NewEmail}",
                @event.CustomerId, @event.OldEmail, @event.NewEmail
            );
        }
    }

    public class CustomerContactNoChangedEventHandler : IDomainEventHandler<CustomerContactNoChanged>
    {
        public void HandleEvent(CustomerContactNoChanged @event)
        {
            var log = AppLogger.CreateLogger<CustomerContactNoChangedEventHandler>();

            log.LogInformation(
                "Customer with id {CustomerId} contact number changed from {OldContactNo} to {NewContactNo}",
                @event.CustomerId, @event.OldContactNo, @event.NewContactNo);
        }
    }

    public class CustomerCreatedEventHandler : IDomainEventHandler<CustomerCreated>
    {
        public void HandleEvent(CustomerCreated @event)
        {
            var log = AppLogger.CreateLogger<CustomerCreatedEventHandler>();

            log.LogInformation(
                "Customer created, data as follows: {Customer}", @event.Customer);
        }
    }

    public class CustomerAddedOrderHandler : IDomainEventHandler<CustomerAddedOrder>
    {
        public void HandleEvent(CustomerAddedOrder @event)
        {
            var log = AppLogger.CreateLogger<CustomerAddedOrder>();

            log.LogInformation(
                "Customer added an order, data as follows: {Order}", @event.Order);
        }
    }
}