namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events
{
    public class CustomerEmailChanged : IDomainEvent
    {
        public long CustomerId { get; set; }
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}