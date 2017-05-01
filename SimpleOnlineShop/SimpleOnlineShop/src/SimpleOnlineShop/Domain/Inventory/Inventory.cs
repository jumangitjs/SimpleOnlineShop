using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory
{
    public class Inventory : IAgreggateRoot
    {

        public long Id { get; set; }

        public virtual string Name { get; protected set; }
        public virtual List<Product> Products { get; protected set; }

        public virtual void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public virtual void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public virtual int RetrieveProductQuantity(Product product)
        {
            return Products.Find(p => p.Name == product.Name).Quantity;
        }

    }
}