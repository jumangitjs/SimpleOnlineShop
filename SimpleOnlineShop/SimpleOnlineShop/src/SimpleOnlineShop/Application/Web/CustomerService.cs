using System;
using System.Collections.Generic;
using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

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
            return _customerRepository.FindAll().AsEnumerableData<CustomerData>();
        }

        public void AddToOrder(long id, IData product, long orderId)
        {
            var inventoryProductData = product as InventoryProductData;
            var productEntity = Product.Create(inventoryProductData.ProductInstance.Name,
                inventoryProductData.ProductInstance.Description,
                inventoryProductData.ProductInstance.Price);


            _customerRepository.FindById(id).Orders
                .FirstOrDefault(o => o.Id == orderId)
                .AddOrder(inventoryProductData.UniqueId, productEntity);

            _customerRepository.UnitOfWork.Commit();
        }

        public void RemoveFromOrder(long id, IData product, long orderId)
        {
            var inventoryProductData = product as InventoryProductData;
            var productEntity = Product.Create(inventoryProductData.ProductInstance.Name,
                inventoryProductData.ProductInstance.Description,
                inventoryProductData.ProductInstance.Price);

            _customerRepository.FindById(id).Orders
                .FirstOrDefault(o => o.Id == orderId)
                .RemoveOrder(inventoryProductData.UniqueId, productEntity);

            _customerRepository.UnitOfWork.Commit();
        }

        public void CreateOrder(long id)
        {
            _customerRepository.FindById(id).Orders.Add(new Order());

            _customerRepository.UnitOfWork.Commit();
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