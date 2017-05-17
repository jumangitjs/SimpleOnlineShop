namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntities
{
    public class UserRole
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }

    public class User : IAgreggateRoot
    {
        public long Id { get; set; }
    }
}