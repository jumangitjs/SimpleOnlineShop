using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleOnlineShop.SimpleOnlineShop.Domain;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class InventoryProductRepository : IInventoryProductRepository
    {
        public InventoryProductRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly UnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public InventoryProduct FindById(long id)
        {
            return _unitOfWork.InventoryProducts
                .Include(ip => ip.ProductInstance)
                .FirstOrDefault(ip => ip.Id == id);
        }

        public IEnumerable<InventoryProduct> FindAll()
        {
            return _unitOfWork.InventoryProducts
                .Include(ip => ip.ProductInstance)
                .AsEnumerable();
        }

        public void Add(InventoryProduct aggregate)
        {
            _unitOfWork.InventoryProducts.Add(aggregate);
        }

        public void Remove(InventoryProduct aggregate)
        {
            _unitOfWork.InventoryProducts.Remove(aggregate);
        }

        public void Modify(InventoryProduct aggregate)
        {
            _unitOfWork.Entry(aggregate).State = EntityState.Modified;
        }

        public void RemoveById(long id)
        {
            Remove(FindById(id));
        }

        public InventoryProduct FindByName(string name)
        {
            return _unitOfWork.InventoryProducts
                .Include(ip => ip.ProductInstance)
                .FirstOrDefault(ip => ip.ProductInstance.Name == name);
        }
    }
}