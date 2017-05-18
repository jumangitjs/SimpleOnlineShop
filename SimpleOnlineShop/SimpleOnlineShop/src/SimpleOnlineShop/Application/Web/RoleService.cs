using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IData RetriveById(long id)
        {
            return _roleRepository.FindById(id).AsData<RoleData>();
        }

        public IEnumerable<IData> RetrieveAll()
        {
            return _roleRepository.FindAll().AsEnumerableData<RoleData>();
        }
    }
}