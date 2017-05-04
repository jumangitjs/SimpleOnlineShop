using System;
using System.Collections.Generic;
using System.Linq;
using NpgsqlTypes;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public class Customer : IAgreggateRoot
    {
        public Customer()
        {
            
        }

        public static Customer Create(string firstName, string lastName, Gender gender, string address, string email, string contactNo)
        {
            return new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                ContactNo = contactNo,
                Gender = gender
            };
        }

        public long Id { get; set; }

        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }

        public virtual string Name => $"{LastName}, {FirstName}";

        public virtual Gender Gender { get; protected set; }

        public virtual string Address { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string ContactNo { get; protected set; }

        private IInventoryRepository inventoryRepository;

        public virtual IList<Product> Products { get; protected set; } = new List<Product>();

        public virtual void AddToCart(Product product)
        {
            try
            {
                Products.Add(inventoryRepository
                    .FindByName("products")
                    .Products
                    .Find(p => p.Name == product.Name));
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public virtual double CheckOut()
        {
            var totalCost = Products.Sum(product => product.Price);
            foreach (var product in Products)
            {
                inventoryRepository
                    .FindByName("products")
                    .Products
                    .Find(p => p.Id == product.Id)
                    .Quantity--;
            }
            Products.Clear();
            return totalCost;
        }

        public virtual void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public virtual void ChangeContactNo(string newNumber)
        {
            ContactNo = newNumber;
        }
    }
}