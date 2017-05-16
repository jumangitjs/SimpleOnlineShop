using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

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
            return _customerService.RetriveById(id) != null ? _customerService.RetriveById(id) : null;
        }

        [HttpPut("{id}/email")]
        public void ChangeEmail(long id, [FromBody] CustomerData data)
        {
            _customerService.ChangeEmail(id, data.Email);
        }

        [HttpPut("{id}/contactno")]
        public void ChangeContactNo(long id, [FromBody] CustomerData data)
        {
            _customerService.ChangeEmail(id, data.ContactNo);
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

        [HttpGet("{id}/order")]
        public IEnumerable<OrderData> RetrieveAllOrders(long id)
        {
            return _customerService.RetrieveAllOrders(id);
        }   


        [HttpPut("{id}/order")]
        public void AddProductToOrder(long id, [FromBody] OrderForm form)
        {
            _customerService.AddProductToOrder(id, form.InventoryName, form.ProductName);
        }

    }
}
