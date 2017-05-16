namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events
{
    public class CustomerAddedOrder : IDomainEvent
    {
        public int CustomerId { get; set; }
        public Order Order { get; set; }
    }
}