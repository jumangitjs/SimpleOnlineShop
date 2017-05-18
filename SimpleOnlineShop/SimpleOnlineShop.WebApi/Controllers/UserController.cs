using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<IData> GetCustomers()
        {
            return _userService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public IData GetCustomer(long id)
        {
            return _userService.RetriveById(id) != null ? _userService.RetriveById(id) : null;
        }

        [HttpPut("{id}/email")]
        public void ChangeEmail(long id, [FromBody] UserData data)
        {
            _userService.ChangeEmail(id, data.Email);
        }

        [HttpPut("{id}/contactno")]
        public void ChangeContactNo(long id, [FromBody] UserData data)
        {
            _userService.ChangeEmail(id, data.ContactNo);
        }

        [HttpPost]
        public User CreateCustomer([FromBody] UserData data)
        {
            return _userService.CreateCustomer(data);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(long id)
        {
            _userService.DeleteCustomer(id);
        }

        [HttpGet("{id}/order")]
        public IEnumerable<OrderData> RetrieveAllOrders(long id)
        {
            return _userService.RetrieveAllOrders(id);
        }   
        
        [HttpPut("{id}/order")]
        public void AddProductToOrder(long id, [FromBody] OrderForm form)
        {
            _userService.AddProductToOrder(id, form.InventoryName, form.ProductName);
        }

        [HttpDelete("{id}/order")]
        public void DeleteOrder(long id, [FromBody] OrderForm form)
        {
            _userService.DeleteOrder(id, form.ProductName);
        }

    }
}
