using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg
{
    public class Inventory : IAggregateRoot
    {
        public static Inventory Create(string name, string description)
        {
            return new Inventory
            {
                Name = name,
                Description = description
            };
        }

        protected Inventory() { }

        public long Id { get; set; }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IList<InventoryProduct> InventoryProducts { get; } = new List<InventoryProduct>();
    }
}