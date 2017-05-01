using System.Collections.Generic;
using SimpleOnlineShop.SimpleOnlineShop.Domain.Inventory;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public class Customer : IAgreggateRoot
    {
        public static Customer Create(string address, string email, string contactNo, string firstName, string lastName, Gender gender)
        {
            return new Customer
            {
                Address = address,
                Email = email,
                ContactNo = contactNo,
                FirstName = firstName,
                LastName = lastName,
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

        public virtual List<Product> Cart { get; protected set; }

        public virtual void AddToCart(Product product)
        {
            Cart.Add(product);
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