using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface ICustomerService : IService
    {
        Customer CreateCustomer(IData customerData);
        void ChangeEmail(long id, string email);
        void ChangeContactNo(long id, string number);
        void DeleteCustomer(long id);
        void AddProductToOrder(long id, string inventoryName, string productName);
        IEnumerable<OrderData> RetrieveAllOrders(long id);
    }
}