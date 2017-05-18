namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events
{
    public class UserAddedOrder : IDomainEvent
    {
        public int CustomerId { get; set; }
        public Order Order { get; set; }
    }
}