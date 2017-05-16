namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events
{
    public class CustomerContactNoChanged : IDomainEvent
    {
        public long CustomerId { get; set; }
        public string OldContactNo { get; set; }
        public string NewContactNo { get; set; }
    }
}