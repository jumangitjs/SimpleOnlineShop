using System;
using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public class Order : IEntity
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        public long Id { get; set; }
        public DateTime OrderDate { get; protected set; }

        public List<Product> Products { get; } = new List<Product>();
        private readonly IProductInventoryRepository _productInventoryRepository = new ProductInventoryRepository(new UnitOfWork());

        public void AddOrder(string uniqueId, Product product)
        {
            _productInventoryRepository.FindByName("products")
                .InventoryProducts.Add(
                    InventoryProduct.Create(uniqueId, product));
        }

        public void RemoveOrder(string uniqueId, Product product)
        {
            _productInventoryRepository.FindByName("products")
                .InventoryProducts.Remove(
                    InventoryProduct.Create(uniqueId, product));
        }
    }
}