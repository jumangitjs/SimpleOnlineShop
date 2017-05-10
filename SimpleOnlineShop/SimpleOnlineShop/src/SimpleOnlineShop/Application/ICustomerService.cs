using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface ICustomerService : IService
    {
        void AddToOrder(long id, IData product, long orderId);
        void RemoveFromOrder(long id, IData product, long orderId);

        Customer CreateCustomer(IData customerData);
        void ChangeEmail(long id, string email);
        void ChangeContactNo(long id, string number);
        void DeleteCustomer(long id);
        void CreateOrder(long id);

    }
}