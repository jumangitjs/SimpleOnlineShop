using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleOnlineShop.SimpleOnlineShop.Application;

namespace SimpleOnlineShop.WebApi.Controllers
{
//    [Authorize]
    [Produces("application/json")]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

//        [Authorize("roles")]
        [HttpGet]
        public IEnumerable<IData> GetAllRoles()
        {
            return _roleService.RetrieveAll();
        }
    }
}