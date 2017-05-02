using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {

        private UnitOfWork CustomerUnitOfWork { get; }

        public CustomerRepository(UnitOfWork customerUnitOfWork)
        {
            CustomerUnitOfWork = customerUnitOfWork;
        }

        public Customer FindById(long id)
        {
            return CustomerUnitOfWork.Customers.Find(id);
        }

        public IEnumerable<Customer> FindAll()
        {
            return CustomerUnitOfWork.Customers.AsEnumerable();
        }

        public void Add(Customer aggregate)
        {
            CustomerUnitOfWork.Customers.Add(aggregate);
        }

        public void Remove(Customer aggregate)
        {
            CustomerUnitOfWork.Customers.Remove(aggregate);
        }

        public void Modify(Customer aggregate)
        {
            CustomerUnitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            CustomerUnitOfWork.Customers.Remove(FindById(id));
        }

        public Customer FindByName(string name)
        {
            return CustomerUnitOfWork.Customers.Last(p => p.Name == name);
        }

    }
}