using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AccountAgg
{
    public class Account : IAggregateRoot
    {
        public long Id { get; set; }

        public virtual string Username { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual User User { get; protected set; }
    }
}