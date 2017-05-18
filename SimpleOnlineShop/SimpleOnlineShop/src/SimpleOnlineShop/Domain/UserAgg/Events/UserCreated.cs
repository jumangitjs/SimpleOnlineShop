namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events
{
    public class UserCreated : IDomainEvent
    {
        public User User { get; set; }
    }
}