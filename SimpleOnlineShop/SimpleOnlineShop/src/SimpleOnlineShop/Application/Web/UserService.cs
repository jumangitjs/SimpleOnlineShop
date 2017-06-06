using System;
using System.Collections.Generic;
using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public UserService(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public IData RetriveById(long id)
        {
            return _userRepository.FindById(id).AsData<UserData>();
        }

        public IEnumerable<IData> RetrieveAll()
        {
            return _userRepository.FindAll()
                .AsEnumerableData<UserData>();
        }

        public void AddProductToOrder(long id, string inventoryName, string productName)
        {
            var inventoryRepository = new InventoryRepository(_userRepository.UnitOfWork as UnitOfWork);

            var product = inventoryRepository.FindByName(inventoryName).InventoryProducts
                .FirstOrDefault(ip => ip.ProductInstance.Name == productName).ProductInstance;

            var order = new Order().Create(product);

            _userRepository.FindById(id).AddOrder(order);
            _userRepository.UnitOfWork.Commit();
        }

        public IEnumerable<OrderData> RetrieveAllOrders(long id)
        {
            return _userRepository.FindById(id).Orders.AsEnumerableData<OrderData>();
        }

        public User CreateCustomer(IData customerData)
        {
            var userDto = customerData as UserData;
            var gender = (Gender) Enum.Parse(typeof(Gender), userDto?.Gender.ToLower());

            var user = User.Create(
                userDto?.FirstName,
                userDto?.LastName,
                gender,
                userDto?.Address,
                userDto?.Email,
                userDto?.ContactNo);     

            _userRepository.Add(user);
            _userRepository.UnitOfWork.Commit();

            return user;
        }

        public void ChangeEmail(long id, string email)
        {
            _userRepository.FindById(id).ChangeEmail(email);
            _userRepository.UnitOfWork.Commit();
        }

        public void ChangeContactNo(long id, string number)
        {
            _userRepository.FindById(id).ChangeContactNo(number);
            _userRepository.UnitOfWork.Commit();
        }

        public void DeleteCustomer(long id)
        {
            _userRepository.RemoveById(id);
            _userRepository.UnitOfWork.Commit();
        }

        public void DeleteOrder(long id, long productId)
        {
            var order = _userRepository.FindById(id).Orders
                .FirstOrDefault(o => o.Product.Id == productId);

            _orderRepository.Remove(order);
            _orderRepository.UnitOfWork.Commit();
        }

        public double Checkout(long id)
        {
            var orders = _userRepository.FindById(id).Orders.AsEnumerable();
            foreach (var order in orders)
            {
                _orderRepository.Remove(order);
            }
            _orderRepository.UnitOfWork.Commit();
            return _userRepository.FindById(id).Checkout();
        }
    }
}