using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.RegexHelper;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.AccountAgg
{
    public class Account : IAggregateRoot
    {
        public static Account Create(string username, string password, User user)
        {
            return new Account
            {
                Username = username,
                Password = password,
                User = user
            };
        }

        public long Id { get; set; }

        public virtual string Username { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual User User { get; protected set; }

        public void ChangeUserName(string username)
        {
            if (RegexUtilities.IsValidUsername(username) && Username != username)
            {
                Username = username;
            }
        }

        public void ChangePassword(string password)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, Password) && password.Length > 4)
            {
                Password = BCrypt.Net.BCrypt.HashPassword(password);
            }
        }
    }
}