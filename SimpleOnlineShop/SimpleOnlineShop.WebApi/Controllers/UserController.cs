using System.Collections.Generic;
using AspNet.Security.OpenIdConnect.Extensions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("customer.read")]
        [HttpGet]
        public IEnumerable<IData> GetCustomers()
        {
            return _userService.RetrieveAll();
        }

        [HttpGet("{id}")]
        public IData GetCustomer(long id)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "user.read"))
                return _userService.RetriveById(id) != null ? _userService.RetriveById(id) : null;

            HttpContext.Response.StatusCode = 403;
            return null;
        }

        [HttpPut("{id}/email")]
        public void ChangeEmail(long id, [FromBody] UserData data)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "user.modify"))
                _userService.ChangeEmail(id, data.Email);
            else
                HttpContext.Response.StatusCode = 403;
        }

        [HttpPut("{id}/contactno")]
        public void ChangeContactNo(long id, [FromBody] UserData data)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "user.modify"))
                _userService.ChangeEmail(id, data.ContactNo);
            else
                HttpContext.Response.StatusCode = 403;
        }
        
        //revise, create customer on the instance of creating an accnt
        [HttpPost]
        public User CreateCustomer([FromBody] UserData data)
        {
            return _userService.CreateCustomer(data);
        }

        [Authorize("customer.delete")]
        [HttpDelete("{id}")]
        public void DeleteCustomer(long id)
        {
            _userService.DeleteCustomer(id);
        }
        
        [HttpGet("{id}/order")]
        public IEnumerable<OrderData> RetrieveAllOrders(long id)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "order.read"))
                return _userService.RetrieveAllOrders(id);

            HttpContext.Response.StatusCode = 403;
            return null;
        }   
        
        [HttpPut("{id}/order")]
        public void AddProductToOrder(long id, [FromBody] OrderForm form)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "order.modify"))
                _userService.AddProductToOrder(id, form.InventoryName, form.ProductName);

            else HttpContext.Response.StatusCode = 403;
        }

        [HttpDelete("{id}/order")]
        public void DeleteOrder(long id, [FromBody] OrderForm form)
        {
            if (CanModifySelf(id) || User.HasClaim("scope", "order.delete"))
                _userService.DeleteOrder(id, form.ProductName);

            else HttpContext.Response.StatusCode = 403;
        }

        private bool CanModifySelf(long userId)
        {
            return User.HasClaim("scope", "employee.self") && long.Parse(User.GetClaim("id")) == userId;
        }
    }
}
