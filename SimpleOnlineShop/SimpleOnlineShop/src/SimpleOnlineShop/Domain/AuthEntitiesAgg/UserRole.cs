using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg
{
    public class UserRole
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}