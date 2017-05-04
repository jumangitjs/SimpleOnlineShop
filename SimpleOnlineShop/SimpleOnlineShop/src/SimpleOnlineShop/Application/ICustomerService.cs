using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface ICustomerService : IService
    {
        IData AddToCart(long id, IData product);
        Customer CreateCustomer(IData customerData);
        void ChangeEmail(long id, string email);
        void ChangeContactNo(long id, string number);
        void DeleteCustomer(long id);
    }
}