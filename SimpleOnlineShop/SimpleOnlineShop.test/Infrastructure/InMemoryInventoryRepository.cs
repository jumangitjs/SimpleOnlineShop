using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.test.Infrastructure
{
    public class InMemoryInventoryRepository : IInventoryRepository
    {
        private readonly InMemoryUnitOfWork _unitOfWork;

        public InMemoryInventoryRepository(InMemoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IUnitOfWork UnitOfWork => _unitOfWork;

        public Inventory FindById(long id)
        {
            return _unitOfWork.Inventories.Find(id);
        }

        public IEnumerable<Inventory> FindAll()
        {
            return _unitOfWork.Inventories.ToList();
        }

        public void Add(Inventory aggregate)
        {
            _unitOfWork.Inventories.Add(aggregate);
        }

        public void Remove(Inventory aggregate)
        {
            _unitOfWork.Inventories.Remove(aggregate);
        }

        public void Modify(Inventory aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _unitOfWork.Inventories.Remove(FindById(id));
        }

        public Inventory FindByName(string name)
        {
            return _unitOfWork.Inventories.Last(i => i.Name == name);
        }
    }
}