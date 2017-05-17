using System.Collections.Generic;
using System.Linq;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IInventoryProductRepository _inventoryProductRepository;

        public InventoryService(IInventoryRepository inventoryRepository, IInventoryProductRepository inventoryProductRepository)
        {
            _inventoryRepository = inventoryRepository;
            _inventoryProductRepository = inventoryProductRepository;
        }

        public IData RetriveById(long id)
        {
            return _inventoryRepository.FindById(id).AsData<InventoryData>();
        }

        public IEnumerable<IData> RetrieveAll()
        {
            return _inventoryRepository.FindAll().AsEnumerableData<InventoryData>();
        }

        public IEnumerable<IData> RetrieveProductsByName(long id, string itemName)
        {
            return _inventoryRepository.FindById(id).InventoryProducts
                .Where(ip => ip.ProductInstance.Name == itemName)
                .AsEnumerableData<InventoryData>();
        }

        public IData RetrieveItemByUniqueId(long id, string uniqueId)
        {
            return _inventoryRepository.FindById(id).InventoryProducts
                .FirstOrDefault(ip => ip.UniqueId == uniqueId)
                .AsData<InventoryData>();
        }

        public void CreateInventory(IData data)
        {
            var inventoryData = data as InventoryData;
            _inventoryRepository.Add(
                Inventory.Create(inventoryData?.Name, inventoryData?.Description));

            _inventoryRepository.UnitOfWork.Commit();
        }

        public void AddProductToInventory(long id, IData data)
        {
            var inventoryProductData = data as InventoryProductData;
            var inventory = _inventoryRepository.FindById(id);

            var productInstance = inventory.InventoryProducts
                                        .FirstOrDefault(p => p.ProductInstance.Name 
                                        == inventoryProductData?.Name)?.ProductInstance
                                            ?? Product.Create(inventoryProductData?.Name,
                                            inventoryProductData?.Brand,
                                            inventoryProductData?.Description,
                                            inventoryProductData.Price);

            var inventoryProdcut = InventoryProduct.Create(inventoryProductData?.UniqueId, productInstance);

            inventory.InventoryProducts.Add(inventoryProdcut);

            _inventoryRepository.UnitOfWork.Commit();
        }

        public void DeleteInventory(long id)
        {
            _inventoryRepository.RemoveById(id);
            _inventoryRepository.UnitOfWork.Commit();
        }

        public void DeleteInventoryProduct(long inventoryId, string productName)
        {
            var inventory = _inventoryRepository.FindById(inventoryId);
            var product = inventory.InventoryProducts.FirstOrDefault(ip => ip.ProductInstance.Name == productName);

            _inventoryProductRepository.Remove(product);
            _inventoryProductRepository.UnitOfWork.Commit();
        }

        public IEnumerable<IData> RetrieveInventoryProducts(long id)
        {
            return _inventoryRepository.FindById(id).InventoryProducts.AsEnumerableData<InventoryProductData>();
        }
    }
}