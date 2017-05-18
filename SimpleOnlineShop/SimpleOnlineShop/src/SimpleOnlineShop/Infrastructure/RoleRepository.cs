using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public RoleRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public Role FindById(long id)
        {
            return _unitOfWork.Roles
                .Include("Permissions.Permission")
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Role> FindAll()
        {
            return _unitOfWork.Roles
                .Include("Permissions.Permission")
                .AsEnumerable();
        }

        public void Add(Role aggregate)
        {
            _unitOfWork.Roles.Add(aggregate);
        }

        public void Remove(Role aggregate)
        {
            _unitOfWork.Roles.Remove(aggregate);
        }

        public void Modify(Role aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            Remove(FindById(id));
        }
    }
}