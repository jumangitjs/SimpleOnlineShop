using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer FindByName(string name);
    }
}