namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events
{
    public class UserEmailChanged : IDomainEvent
    {
        public long CustomerId { get; set; }
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}