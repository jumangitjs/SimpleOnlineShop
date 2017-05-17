using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public class Inventory : IAgreggateRoot
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
        public List<InventoryProduct> InventoryProducts { get; } = new List<InventoryProduct>();
    }
}