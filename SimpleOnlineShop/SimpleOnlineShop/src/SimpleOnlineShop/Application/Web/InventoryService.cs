using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using SimpleOnlineShop.SimpleOnlineShop.Application.Web.DTO;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.CrossCutting.Extension;

namespace SimpleOnlineShop.SimpleOnlineShop.Application.Web
{
    public class InventoryService : IInventoryService
    {

        private readonly IProductInventoryRepository _productInventoryRepository;

        public InventoryService(IProductInventoryRepository productInventoryRepository)
        {
            _productInventoryRepository = productInventoryRepository;
        }

        public IData RetriveById(long id)
        {
            return _productInventoryRepository.FindById(id).AsData<InventoryData>();
        }

        public IEnumerable<IData> RetrieveAll()
        {
            return _productInventoryRepository.FindAll().AsEnumerable<InventoryData>();
        }

        public IEnumerable<IData> RetrieveProductsByName(long id, string itemName)
        {
            return _productInventoryRepository.FindById(id)
                .InventoryProducts.Where(ip => ip.ProductInstance.Name == itemName )
                .AsEnumerable<InventoryData>();
        }

        public IData RetrieveItemByUniqueId(long id, string uniqueId)
        {
            return _productInventoryRepository.FindById(id)
                .InventoryProducts.FirstOrDefault(ip => ip.UniqueId == uniqueId)
                .AsData<InventoryData>();
        }

        public void CreateInventory(IData data)
        {
            var inventoryData = data as InventoryData;
            _productInventoryRepository.Add(
                ProductInventoryList.Create(inventoryData.Name, inventoryData.Description));

            _productInventoryRepository.UnitOfWork.Commit();
        }

        public void AddProductToInventory(long id, IData data)
        {
            var inventoryProductData = data as InventoryProductData;
            var inventory = _productInventoryRepository.FindById(id);

            var productInstance = inventory.InventoryProducts
                                    .FirstOrDefault(p => p.ProductInstance.Name ==
                                        inventoryProductData.ProductInstance?.Name)?.ProductInstance
                                    ?? Product.Create(inventoryProductData.ProductInstance.Name,
                                                        inventoryProductData.ProductInstance.Description,
                                                        inventoryProductData.ProductInstance.Price);

            var inventoryProdcut = InventoryProduct.Create(inventoryProductData.UniqueId, productInstance);

            inventory.InventoryProducts.Add(inventoryProdcut);

            _productInventoryRepository.UnitOfWork.Commit();
        }
    }
}