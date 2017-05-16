using System;
using Newtonsoft.Json;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public class Order : IEntity
    {
        public Order Create(Product product) => new Order {OrderDate = DateTime.Now, Product = product};
    
        protected internal Order() { }

        public long Id { get; set; }
        public long CustomerId { get; protected set; }
        public long ProductId { get; protected set; }

        public DateTime OrderDate { get; protected set; }

        public Product Product { get; protected set; }
        public Customer Customer { get; protected set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}