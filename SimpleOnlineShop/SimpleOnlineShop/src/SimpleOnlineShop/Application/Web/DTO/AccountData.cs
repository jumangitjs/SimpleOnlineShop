namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO
{
    public class AccountData
    {
        public long Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public UserData User { get; set; }
    }
}