namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public class Product : IEntity
    {
        public static Product Create(string itemId, string name, string description, double price, int quantity)
        {
            return new Product
            {
                ItemId = itemId,
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,

            };
        }

        public long Id { get; set; }

        public string ItemId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual int Quantity { get; protected set; }
    }
}