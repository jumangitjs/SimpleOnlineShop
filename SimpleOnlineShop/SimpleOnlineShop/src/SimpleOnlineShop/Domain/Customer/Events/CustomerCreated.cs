namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events
{
    public class CustomerCreated : IDomainEvent
    {
        public Customer Customer { get; set; }
    }
}