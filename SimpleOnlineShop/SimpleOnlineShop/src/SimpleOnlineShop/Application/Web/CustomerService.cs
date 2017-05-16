using System;
using System.Collections.Generic;
using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer.Events;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IData RetriveById(long id)
        {
            return _customerRepository.FindById(id).AsData<CustomerData>();
        }

        public IEnumerable<IData> RetrieveAll()
        {
            return _customerRepository.FindAll()
                .AsEnumerableData<CustomerData>();
        }

        public void AddProductToOrder(long id, string inventoryName, string productName)
        {
            var inventoryRepository = new InventoryRepository(_customerRepository.UnitOfWork as UnitOfWork);

            var product = inventoryRepository.FindByName(inventoryName).InventoryProducts
                .FirstOrDefault(ip => ip.ProductInstance.Name == productName).ProductInstance;

            var order = new Order().Create(product);

            _customerRepository.FindById(id).AddOrder(order);
            
            _customerRepository.UnitOfWork.Commit();
        }

        public IEnumerable<OrderData> RetrieveAllOrders(long id)
        {
            return _customerRepository.FindById(id).Orders.AsEnumerableData<OrderData>();
        }

        public Customer CreateCustomer(IData customerData)
        {
            var customerDTO = customerData as CustomerData;
            var gender = (Gender) Enum.Parse(typeof(Gender), customerDTO.Gender);

            var customer = Customer.Create(
                customerDTO.FirstName,
                customerDTO.LastName,
                gender,
                customerDTO.Address,
                customerDTO.Email,
                customerDTO.ContactNo);

            _customerRepository.Add(customer);
            _customerRepository.UnitOfWork.Commit();

            return customer;
        }

        public void ChangeEmail(long id, string email)
        {
            _customerRepository.FindById(id).ChangeEmail(email);
            _customerRepository.UnitOfWork.Commit();
        }

        public void ChangeContactNo(long id, string number)
        {
            _customerRepository.FindById(id).ChangeContactNo(number);
            _customerRepository.UnitOfWork.Commit();
        }

        public void DeleteCustomer(long id)
        {
            _customerRepository.RemoveById(id);
            _customerRepository.UnitOfWork.Commit();
        }
    }
}