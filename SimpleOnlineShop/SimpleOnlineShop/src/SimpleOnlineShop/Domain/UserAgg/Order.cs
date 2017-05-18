using System;
using Newtonsoft.Json;
using SimpleOnlineShop.SimpleOnlineShop.Domain.InventoryAgg;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg
{
    public class Order : IAggregateRoot
    {
        public Order Create(Product product) => new Order {OrderDate = DateTime.Now, Product = product};
    
        protected internal Order() { }

        public long Id { get; set; }
        public long UserId { get; protected set; }
        public long ProductId { get; protected set; }

        public DateTime OrderDate { get; protected set; }

        public Product Product { get; protected set; }
        public User User { get; protected set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}