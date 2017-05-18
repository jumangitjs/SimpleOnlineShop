using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg;

namespace SimpleOnlineShop.test.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {

        private readonly InMemoryUnitOfWork _unitOfWork;

        public InMemoryUserRepository(InMemoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public User FindById(long id)
        {
            return _unitOfWork.Customers.Find(id);
        }

        public IEnumerable<User> FindAll()
        {
            return _unitOfWork.Customers.AsEnumerable();
        }

        public void Add(User aggregate)
        {
            _unitOfWork.Customers.Add(aggregate);
        }

        public void Remove(User aggregate)
        {
            _unitOfWork.Customers.Remove(aggregate);
        }

        public void Modify(User aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _unitOfWork.Customers.Remove(FindById(id));
        }

        public User FindByName(string name)
        {
            return _unitOfWork.Customers.Last(p => p.Name == name);
        }
    }
}