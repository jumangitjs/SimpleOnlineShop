using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.test.Infrastructure
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {

        private readonly InMemoryUnitOfWork _unitOfWork;

        public InMemoryCustomerRepository(InMemoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public Customer FindById(long id)
        {
            return _unitOfWork.Customers.Find(id);
        }

        public IEnumerable<Customer> FindAll()
        {
            return _unitOfWork.Customers.AsEnumerable();
        }

        public void Add(Customer aggregate)
        {
            _unitOfWork.Customers.Add(aggregate);
        }

        public void Remove(Customer aggregate)
        {
            _unitOfWork.Customers.Remove(aggregate);
        }

        public void Modify(Customer aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _unitOfWork.Customers.Remove(FindById(id));
        }

        public Customer FindByName(string name)
        {
            return _unitOfWork.Customers.Last(p => p.Name == name);
        }
    }
}