using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class UserRepository : IUserRepository
    {

        private readonly UnitOfWork _customerUnitOfWork;

        public IUnitOfWork UnitOfWork => _customerUnitOfWork;

        public UserRepository(UnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        public User FindById(long id)
        {
            return _customerUnitOfWork.Users
                .Include(p => p.Orders)
                .Include("Orders.Product")
                .FirstOrDefault(c => c.Id == id);

        }

        public IEnumerable<User> FindAll()
        {
            return _customerUnitOfWork.Users
                .Include(p => p.Orders)
                .Include("Orders.Product")
                .AsEnumerable();
        }

        public void Add(User aggregate)
        {
            _customerUnitOfWork.Users.Add(aggregate);
        }

        public void Remove(User aggregate)
        {
            _customerUnitOfWork.Users.Remove(aggregate);
        }

        public void Modify(User aggregate)
        {
            _customerUnitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _customerUnitOfWork.Users.Remove(FindById(id));
        }

        public User FindByName(string name)
        {
            return _customerUnitOfWork.Users.Last(p => p.Name == name);
        }

    }
}