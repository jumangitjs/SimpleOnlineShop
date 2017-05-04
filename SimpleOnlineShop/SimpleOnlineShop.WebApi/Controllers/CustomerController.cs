using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<IData> GetCustomers()
        {
            return _customerService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public IData GetCustomer(long id)
        {
            return _customerService.RetriveById(id) != null ? _customerService.RetriveById(id) : throw new ArgumentException("User ID Not found");
        }

        [HttpPost]
        public Customer CreateCustomer([FromBody] CustomerData data)
        {
            return _customerService.CreateCustomer(data);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(long id)
        {
            _customerService.DeleteCustomer(id);
        }

    }
}
