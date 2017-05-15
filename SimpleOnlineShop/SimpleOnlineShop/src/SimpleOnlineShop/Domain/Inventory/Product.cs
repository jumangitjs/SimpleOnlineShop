using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public class Product : IEntity
    {
        public static Product Create(string name, string description, double price)
        {
            return new Product
            {
                Name = name,
                Description = description,
                Price = price
            };
        }

        public long Id { get; set; }

        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double Price { get; protected set; }
    }
}