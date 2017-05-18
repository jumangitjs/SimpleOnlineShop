namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByName(string name);
    }
}