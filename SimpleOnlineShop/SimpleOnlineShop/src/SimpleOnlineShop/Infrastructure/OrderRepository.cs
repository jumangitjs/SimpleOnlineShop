using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Customer;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork;

        public OrderRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Order FindById(long id)
        {
            return _unitOfWork.Orders
                .Include(o => o.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> FindAll()
        {
            return _unitOfWork.Orders
                .Include(o => o.Product)
                .AsEnumerable();
        }

        public void Add(Order aggregate)
        {
            _unitOfWork.Orders.Add(aggregate);
        }

        public void Remove(Order aggregate)
        {
            _unitOfWork.Orders.Remove(aggregate);
        }

        public void Modify(Order aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            Remove(FindById(id));
        }
    }
}