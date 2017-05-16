using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class InventoryRepository : IInventoryRepository
    {

        private readonly UnitOfWork _unitOfWork;

        public InventoryRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public InventoryRepository()
        {
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public ProductInventoryList FindById(long id)
        {
            return _unitOfWork.Inventories
                .Include(p => p.InventoryProducts)
                .Include("InventoryProducts.ProductInstance")
                .FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<ProductInventoryList> FindAll()
        {
            return _unitOfWork.Inventories
                .Include(i => i.InventoryProducts)
                .Include("InventoryProducts.ProductInstance")
                .AsEnumerable();
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
            Remove(FindById(id));
        }

        public ProductInventoryList FindByName(string name)
        {
           return _unitOfWork.Inventories
                .Include(p => p.InventoryProducts)
                .Include("InventoryProducts.ProductInstance")
                .FirstOrDefault(i => i.Name == name);
        }
    }
}