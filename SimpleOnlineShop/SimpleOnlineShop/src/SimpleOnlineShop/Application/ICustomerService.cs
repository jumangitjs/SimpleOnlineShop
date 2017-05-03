namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface ICustomerService : IService
    {
        IData AddToCart(long id, IData product);
        void CreateCustomer(IData customerData);
        void ChangeEmail(long id, string email);
        void ChangeContactNo(long id, string number);
    }
}