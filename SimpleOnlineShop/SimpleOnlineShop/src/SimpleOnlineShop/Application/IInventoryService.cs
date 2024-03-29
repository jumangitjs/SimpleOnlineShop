﻿using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface IInventoryService : IService
    {
        IEnumerable<IData> RetrieveProductsByName(long id, string itemName);
        IData RetrieveItemByUniqueId(long id, string uniqueId);
        void CreateInventory(IData data);
        void AddProductToInventory(long id, IData data);

        void DeleteInventory(long id);
        void DeleteInventoryProduct(long inventoryId, long productId);
        IEnumerable<IData> RetrieveInventoryProducts(long id);
    }
}