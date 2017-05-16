using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
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

        public ProductInventoryList FindById(long id)
        {
            return _unitOfWork.Inventories.Find(id);
        }

        public IEnumerable<ProductInventoryList> FindAll()
        {
            return _unitOfWork.Inventories.ToList();
        }

        public void Add(ProductInventoryList aggregate)
        {
            _unitOfWork.Inventories.Add(aggregate);
        }

        public void Remove(ProductInventoryList aggregate)
        {
            _unitOfWork.Inventories.Remove(aggregate);
        }

        public void Modify(ProductInventoryList aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            _unitOfWork.Inventories.Remove(FindById(id));
        }

        public ProductInventoryList FindByName(string name)
        {
            return _unitOfWork.Inventories.Last(i => i.Name == name);
        }
    }
}