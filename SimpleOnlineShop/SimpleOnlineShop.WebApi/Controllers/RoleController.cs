using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;

namespace SimpleOnlineShop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IEnumerable<IData> GetAllRoles()
        {
            return _roleService.RetrieveAll();
        }
    }
}