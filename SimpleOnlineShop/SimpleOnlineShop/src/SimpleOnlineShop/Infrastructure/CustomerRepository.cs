using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly UnitOfWork _customerUnitOfWork;

        public IUnitOfWork UnitOfWork => _customerUnitOfWork;

        public CustomerRepository(UnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        public Customer FindById(long id)
        {
            return _customerUnitOfWork.Customers
                .Include(p => p.Orders)
                .Include("Orders.Product")
                .FirstOrDefault(c => c.Id == id);

        }

        public IEnumerable<Customer> FindAll()
        {
            return _customerUnitOfWork.Customers
                .Include(p => p.Orders)
                .Include("Orders.Product")
                .AsEnumerable();
        }

        public void Add(Customer aggregate)
        {
            _customerUnitOfWork.Customers.Add(aggregate);
        }

        public void Remove(Customer aggregate)
        {
            _customerUnitOfWork.Customers.Remove(aggregate);
        }

        public void Modify(Customer aggregate)
        {
            _customerUnitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _customerUnitOfWork.Customers.Remove(FindById(id));
        }

        public Customer FindByName(string name)
        {
            return _customerUnitOfWork.Customers.Last(p => p.Name == name);
        }

    }
}