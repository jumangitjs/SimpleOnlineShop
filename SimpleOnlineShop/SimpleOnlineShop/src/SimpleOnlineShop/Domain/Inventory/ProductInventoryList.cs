using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public class ProductInventoryList : IAgreggateRoot
    {
        public static ProductInventoryList Create(string name, string description)
        {
            return new ProductInventoryList
            {
                Name = name,
                Description = description
            };
        }

        public long Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<InventoryProduct> InventoryProducts { get; protected set; } = new List<InventoryProduct>();
    }
}