using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.Customer
{
    public class Customer : IAgreggateRoot
    {
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
    

        public virtual List<Order> Orders { get; protected set; } = new List<Order>();

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