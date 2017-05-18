namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events
{
    public class UserContactNoChanged : IDomainEvent
    {
        public long CustomerId { get; set; }
        public string OldContactNo { get; set; }
        public string NewContactNo { get; set; }
    }
}