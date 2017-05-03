using System;
using System.Collections.Generic;
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
            return _customerRepository.FindAll().AsEnumerable<CustomerData>();
        }

        public IData AddToCart(long id, IData productData)
        {
            var productDTO = productData as ProductData;
            var product = _customerRepository.FindById(id).AddToCart(
                Product.Create(
                    productDTO.ItemId,
                    productDTO.Name,
                    productDTO.Description,
                    productDTO.Price,
                    productDTO.Quantity
                    ));
            _customerRepository.UnitOfWork.Commit();

            return product.AsData<ProductData>();
        }

        public void CreateCustomer(IData customerData)
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
    }
}